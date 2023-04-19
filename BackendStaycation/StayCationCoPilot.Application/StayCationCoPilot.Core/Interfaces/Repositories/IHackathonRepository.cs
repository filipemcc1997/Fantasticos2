using StayCationCoPilot.Core.Models;

namespace StayCationCoPilot.Core.Interfaces.Repositories
{
    public interface IHackathonRepository
    {
        //Create repository interface methods here with the following signature: GetHotels(), GetHotelById(int id), ReserveHotel(int hotelId), PaymentHotel(int hotelId) and Login(nt userId, string password)

        Task<List<Hotel>> GetHotels();
        Task<Hotel> GetHotelById(int id);
        Task<bool> ReserveHotel(Reserve reserveHotel);
        Task<bool> PaymentHotel(Payment payment);
        Task<User> Login(int userId, string password);
    }
}
