using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ApplicationDbContext context) : ControllerBase
    {

        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Hello World {id}");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(id);
        }

    }
}
