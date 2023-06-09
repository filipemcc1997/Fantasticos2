using Microsoft.AspNetCore.Mvc;
using StayCationCoPilot.Core.Interfaces.Repositories;
using StayCationCoPilot.Core.Models;

namespace StayCationCoPilot.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHackathonRepository _hackathonRepository;

        private readonly ILogger<HotelsController> _logger;
        public HotelsController(ILogger<HotelsController> logger,
                                IHackathonRepository hackathonRepository)
        {
            _logger = logger;
            _hackathonRepository = hackathonRepository;

        }


        //Create GetHotels(), GetHotelById(int id), ReserveHotel(int hotelId), PaymentHotel(int hotelId) and Login(int userId, string password) methods here        //Add the following code to the GetHotels() method:
        [HttpGet]
        [Route("hotels")]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _hackathonRepository.GetHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Add the following code to the GetHotelById(int id) method:
        [HttpGet]
        [Route("hotels/{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            try
            {
                var hotel = await _hackathonRepository.GetHotelById(id);
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Add the following code to the ReserveHotel(Reserve reserveHotel) method:
        [HttpPost]
        [Route("hotels/reserve")]
        public IActionResult ReserveHotel([FromBody] Reserve reserveHotel)
        {
            try
            {
                _hackathonRepository.ReserveHotel(reserveHotel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Add the following code to the PaymentHotel(int hotelId) method:
        [HttpPost]
        [Route("hotels/payment")]
        public IActionResult PaymentHotel([FromBody] Payment payment)
        {
            try
            {
                // call repository method
                _hackathonRepository.PaymentHotel(payment);
                return Ok();
                //return Ok(reserve);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Add the following code to the Login(int userId, string password) method:
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            try
            {
                var result = await _hackathonRepository.Login(user.UserId, user.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}