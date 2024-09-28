using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IRepository<ProductItem> repository) : ControllerBase
    {
        private readonly IRepository<ProductItem> _repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItem>>> Index()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductItemRequestDto requestDto)
        {
            var product = new ProductItem()
            {
                Name = requestDto.Name,
                Description = requestDto.Description,
            };

            await _repository.AddAsync(product);

            return Ok(requestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItem>> Get(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductItemRequestDto requestDto)
        {
            var product =  await _repository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(requestDto.Name))
            {
                product.Name = requestDto.Name;
            }
            if (!string.IsNullOrEmpty(requestDto.Description))
            {
                product.Description = requestDto.Description;
            }
            await _repository.UpdateAsync(id, product);
            return Ok(requestDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok(id);
        }

    }
}
