using Dapper;
using Microsoft.Extensions.Options;
using StayCationCoPilot.Core.Interfaces.Repositories;
using StayCationCoPilot.Core.Models;
using StayCationCoPilot.Core.Settings;
using System.Data.SqlClient;

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

        public async Task<Hotel> GetHotels()
        {
            try
            {
                await using var connection = new SqlConnection(_repositorySettings.ConnectionString);
                await connection.OpenAsync();

                var query = @"SELECT * FROM tblHotels";

                var result = connection.Query<Hotel>(query).ToList();
            }
            catch (SqlException ex)
            {
                throw;
            }

            return null;
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            try
            {
                await using var connection = new SqlConnection(_repositorySettings.ConnectionString);
                await connection.OpenAsync();
                var query = @"SELECT * FROM tblHotels WHERE HotelId = @id";
                var result = connection.Query<Hotel>(query);

                if (result != null)
                    return (Hotel)result;
            }
            catch (SqlException ex)
            {
                throw;
            }
            return null;

        }

        public async Task<User> Login(int userId, string password)
        {
            //create login method here with columns username and password protect string against sql injection
            try
            {
                await using var connection = new SqlConnection(_repositorySettings.ConnectionString);
                await connection.OpenAsync();
                var query = @"SELECT * FROM tblUsers WHERE UserName = @userId AND Password = @password";
                var result = connection.Query<User>(query);
                if (result != null)
                    return (User)result;
            }
            catch (SqlException ex)
            {
                throw;
            }
            return null;

        }

        public void PaymentHotel(int hotelId)
        {
            //create PaymentHotel method here

        }
        public void ReserveHotel(int hotelId)
        {
            //create ReserveHotel method here

            throw new System.NotImplementedException();
        }
    }
}
