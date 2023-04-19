using Staycation.Models;
using System.Net;

namespace Staycation.Gateway
{
    public class HotelGateway
    {
        public HttpClient _httpClient;
        public HotelGateway( HttpClient httpClient)
        {
            //httpClient.BaseAddress = new Uri("");
            _httpClient = httpClient;
        }

        //generate a method to get all hotels
        public async Task<List<Hotel>> GetAllHotels()
        {
            var response = await _httpClient.GetAsync("https://staycationapi.azurewebsites.net/hotels/hotels");
            var hotels = await response.Content.ReadFromJsonAsync<List<Hotel>>();
            //List<Hotel> hotels = new List<Hotel>();
            //hotels.Add(new Hotel()
            //{
            //    Id = 1,
            //    Name = "Hotel 1",
            //    Description = "Description 1",
            //    Address = "Address 1",
            //    Image = "https://picsum.photos/200/300",
            //    Price = "Price 1",
            //    Rating = "Rating 1"
            //});
            //hotels.Add(new Hotel()
            //{
            //    Id= 2,
            //    Name = "Hotel 2",
            //    Description = "Description 2",
            //    Address = "Address 2",
            //    Image = "https://picsum.photos/200/300",
            //    Price = "Price 2",
            //    Rating = "Rating 2"
            //});
            //hotels.Add(new Hotel()
            //{
            //    Id = 3,
            //    Name = "Hotel 3",
            //    Description = "Description 3",
            //    Address = "Address 3",
            //    Image = "https://picsum.photos/200/300",
            //    Price = "Price 3",
            //    Rating = "Rating 3"
            //});


            return hotels;
        }

        

        //generate a method to get a single hotel
        public async Task<Hotel> GetHotel(int id)
        {
            var response = await _httpClient.GetAsync($"https://staycationapi.azurewebsites.net/hotels/hotels/{id}");
            var hotel = await response.Content.ReadFromJsonAsync<Hotel>();

            //var hotel =  (new Hotel()
            // {
            //     Id = 1,
            //     Name = "Hotel " +id,
            //     Description = "Description "+ id,
            //     Address = "Address "+ id,
            //     Image = "https://picsum.photos/200/300",
            //     Price = "Price "+ id,
            //     Rating = "Rating "+ id
            // });
            return hotel;
        }
        //generate a method to create a hotel
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/hotel", hotel);
            var createdHotel = await response.Content.ReadFromJsonAsync<Hotel>();
            return createdHotel;
        }
        //generate a method to edit a hotel
        public async Task<Hotel> EditHotel(int id, Hotel hotel)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/hotel/{id}", hotel);
            var editedHotel = await response.Content.ReadFromJsonAsync<Hotel>();
            return editedHotel;
        }
        //generate a method to delete a hotel
        public async Task<HttpStatusCode> DeleteHotel(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/hotel/{id}");
            return response.StatusCode;
        }

        //generate a method to create a hotel booking
        public async Task<HotelBooking> CreateHotelBooking(HotelBooking hotelBooking)
        {
            var response = await _httpClient.PostAsJsonAsync("api/hotelBooking", hotelBooking);
            var createdHotelBooking = await response.Content.ReadFromJsonAsync<HotelBooking>();
            return createdHotelBooking;
        }
        //generate a method to get all hotel bookings
        public async Task<List<HotelBooking>> GetAllHotelBookings()
        {
            var response = await _httpClient.GetAsync("api/hotelBooking");
            var hotelBookings = await response.Content.ReadFromJsonAsync<List<HotelBooking>>();
            return hotelBookings;
        }
        //generate a method to get a single hotel booking
        public async Task<HotelBooking> GetHotelBooking(string id)
        {
            var response = await _httpClient.GetAsync($"api/hotelBooking/{id}");
            var hotelBooking = await response.Content.ReadFromJsonAsync<HotelBooking>();
            return hotelBooking;
        }
        //generate a method to edit a hotel booking
        public async Task<HotelBooking> EditHotelBooking(string id, HotelBooking hotelBooking)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/hotelBooking/{id}", hotelBooking);
            var editedHotelBooking = await response.Content.ReadFromJsonAsync<HotelBooking>();
            return editedHotelBooking;
        }
        //generate a method to delete a hotel booking
        public async Task<HttpStatusCode> DeleteHotelBooking(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/hotelBooking/{id}");
            return response.StatusCode;
        }
        
    }

}
