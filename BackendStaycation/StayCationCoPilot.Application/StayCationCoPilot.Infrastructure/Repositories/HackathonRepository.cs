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

        public async Task<List<Hotel>> GetHotels()
        {
            try
            {
                await using var connection = new SqlConnection(_repositorySettings.ConnectionString);
                await connection.OpenAsync();

                var query = @"SELECT * FROM tblHotels";

                var result = connection.Query<Hotel>(query).ToList();

                if (result != null || result.Count > 0)
                    return result;
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
                var query = $"SELECT * FROM tblHotels WHERE id = {id}";
                var result = connection.QueryFirst<Hotel>(query);

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

        public async Task<bool> PaymentHotel(Payment payment)
        {
            //update tblReserve setting BookingPaymentStatus and BookingPaymentType to Paid and Credit Card where BookingId = payment.Boo            //protect string against sql injectionkingId
            try
            {
                await using var connection = new SqlConnection(_repositorySettings.ConnectionString);
                await connection.OpenAsync();
                var query = @"UPDATE tblReserve SET BookingPaymentStatus = @bookingPaymentStatus, BookingPaymentType = @bookingPaymentType WHERE BookingId = @bookingId";
                var affectedRows = connection.Execute(query, payment);
                if (affectedRows > 0)
                    return true;
            }
            catch (SqlException ex)
            {
                throw;
            }
            return false;
        }
        public async Task<bool> ReserveHotel(Reserve reserveHotel)
        {
            try
            {
                await using var connection = new SqlConnection(_repositorySettings.ConnectionString);
                await connection.OpenAsync();
                var query = @"INSERT INTO tblReserve (HotelName, HotelAddress, HotelImage, HotelPrice, HotelRating, HotelDescription, HotelId, UserId, BookingId, BookingDate, BookingStatus, BookingTotal, BookingTotalNights, BookingGuests, BookingRooms, BookingPaymentType, BookingPaymentStatus) VALUES (@hotelName, @hotelAddress, @hotelImage, @hotelPrice, @hotelRating, @hotelDescription, @hotelId, @userId, @bookingId, @bookingDate, @bookingStatus, @bookingTotal, @bookingTotalNights, @bookingGuests, @bookingRooms, @bookingPaymentType, @bookingPaymentStatus)";
                var affectedRows = connection.Execute(query, reserveHotel);
                if (affectedRows > 0)
                    return true;
            }
            catch (SqlException ex)
            {
                throw;
            }
            return false;
        }
    }
}
