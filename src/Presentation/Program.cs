using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["MSSQL_CONNECTIONSTRING"], b => b.MigrationsAssembly("Infrastructure"));
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = $"{builder.Configuration["REDIS_HOST"]}:{builder.Configuration["REDIS_PORT"]}";
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API V1");
        c.RoutePrefix = string.Empty; // Launch Swagger UI at the root URL
    });
}

app.MapControllers();
app.Run();


// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();

//     ConfigurationOptions configuration = new ConfigurationOptions
//     {
//         EndPoints = { $"{Environment.GetEnvironmentVariable("REDIS_HOST")}:{Environment.GetEnvironmentVariable("REDIS_PORT")}" },
//     };
//     var _redis = ConnectionMultiplexer.Connect(configuration);
//     var db = _redis.GetDatabase();
//     db.Ping();
//     Console.WriteLine("Connected to Redis");


// var connectionString = Environment.GetEnvironmentVariable("MSSQL_CONNECTIONSTRING");
// var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
// optionsBuilder.UseSqlServer(connectionString);

// using (var context = new ApplicationDbContext(optionsBuilder.Options))
// {
//         context.Database.EnsureCreated();
//         Console.WriteLine("Connected to SQL Server");
// }

//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();


// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
