using StayCationCoPilot.Core.Models;

namespace StayCationCoPilot.Core.Interfaces.Repositories
{
    public interface IHackathonRepository
    {
        //Create repository interface methods here with the following signature: GetHotels(), GetHotelById(int id), ReserveHotel(int hotelId), PaymentHotel(int hotelId) and Login(nt userId, string password)

        Task<Hotel> GetHotels();
        Task<Hotel> GetHotelById(int id);
        void ReserveHotel(int hotelId);
        void PaymentHotel(int hotelId);
        Task<User> Login(int userId, string password);
    }
}
