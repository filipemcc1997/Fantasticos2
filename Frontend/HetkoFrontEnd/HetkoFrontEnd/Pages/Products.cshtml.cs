using HetkoFrontEnd.Gateways;
using HetkoFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HetkoFrontEnd.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ILogger<ProductsModel> _logger;
        public APIGateway _apiGateway;

        public ProductsModel(ILogger<ProductsModel> logger, APIGateway apiGateway)
        {
            _logger = logger;
            _apiGateway = apiGateway;
        }

        [BindProperty]
        public static IList<Product> Products { get; set; }

        public async Task OnGet()
        {
            Products = await _apiGateway.GetProducts();
        }
    }
}