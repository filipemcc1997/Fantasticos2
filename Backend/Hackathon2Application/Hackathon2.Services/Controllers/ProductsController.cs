using Hackathon2.Core.Interfaces.Repositories;
using Hackathon2.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon2.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ProductsController> _logger;
        private readonly IHackathonRepository _hackathonRepository;

        public ProductsController(
            ILogger<ProductsController> logger,
            HackathonRepository hackathonRepository
            )
        {
            _logger = logger;
            _hackathonRepository = hackathonRepository;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<IEnumerable<WeatherForecast>> GetProductsAsync()
        {
            var products = await _hackathonRepository.GetProductsAsync();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}