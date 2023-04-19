using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Staycation.Gateway;
using Staycation.Models;

namespace Staycation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public HotelGateway _hotelGateway;

        public IndexModel(ILogger<IndexModel> logger, HotelGateway hotelGateway)
        {
            _logger = logger;
            _hotelGateway = hotelGateway;
        }

        public IList<Hotel>? Hotels { get; set; }

        public void OnGet()
        {
            //Call method to Gateway to get all hotels
            Hotels = _hotelGateway.GetAllHotels().Result;
            ViewData["Hotels"] = Hotels;
        }

        //public IActionResult OnPostBookNow(int id)
        //{
        //    return RedirectToPage("PDPHotel", id);
        //}
    }
}