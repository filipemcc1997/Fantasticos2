using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Staycation.Gateway;
using Staycation.Models;

namespace Staycation.Pages
{
    public class HotelDetailsModel : PageModel
    {
        public HotelGateway _hotelGateway;

        public HotelDetailsModel( HotelGateway hotelGateway)
        {
            _hotelGateway = hotelGateway;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            var hoteldetails = await _hotelGateway.GetHotel(id);
            ViewData["hoteldetails"] = hoteldetails;
            return Page();
        }
    }
}
