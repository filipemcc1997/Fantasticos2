using Hackathon2.Core.Interfaces.Repositories;
using Hackathon2.Infrastructure.Repositories;
using Hackathon2.Services.Data.Contracts;
using Hackathon2.Core.Models;
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
            IHackathonRepository hackathonRepository
            )
        {
            _logger = logger;
            _hackathonRepository = hackathonRepository;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _hackathonRepository.GetProductsAsync();


            return new List<Product>();
        }

        [HttpPost(Name = "AddCart")]
        public async Task<IActionResult> AddCart([FromBody] AddCartRequest body)
        {
            try
            {
                var products = await _hackathonRepository.GetProductsAsync();

                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}