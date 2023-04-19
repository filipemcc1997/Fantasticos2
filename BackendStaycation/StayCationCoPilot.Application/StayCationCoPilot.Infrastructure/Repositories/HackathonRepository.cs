using Microsoft.Extensions.Options;
using StayCationCoPilot.Core.Interfaces.Repositories;
using StayCationCoPilot.Core.Models;
using StayCationCoPilot.Core.Settings;

namespace StayCationCoPilot.Infrastructure.Repositories
{
    public class HackathonRepository : IHackathonRepository
    {
        private readonly RepositorySettings _repositorySettings;

        public HackathonRepository(
               IOptions<RepositorySettings> repositoryOptions)
        {
            _repositorySettings = repositoryOptions.Value;
        }
        //implement the methods from the interface here

        public Hotel GetHotelById(int id)
        {
            //use entityFramework to connect to _repositorySettings.ConnectionString   
            throw new System.NotImplementedException();
        }
        public Hotel GetHotels()
        {
            throw new System.NotImplementedException();
        }
        public void Login(int userId, string password)
        {
            throw new System.NotImplementedException();
        }
        public void PaymentHotel(int hotelId)
        {
            throw new System.NotImplementedException();
        }
        public void ReserveHotel(int hotelId)
        {
            throw new System.NotImplementedException();
        }
    }
}
