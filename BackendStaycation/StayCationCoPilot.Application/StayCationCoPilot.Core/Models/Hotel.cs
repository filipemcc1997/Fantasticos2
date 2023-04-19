namespace StayCationCoPilot.Core.Models
{
    public class Hotel
    {
        //Create properties for HotelId, Name, Address, City, State, Zip, Country, Phone, Email, Website, Description, Amenities, ImageUrl, Rating, Price, and IsAvailable        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Amenities { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
