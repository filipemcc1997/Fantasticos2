namespace StayCationCoPilot.Core.Models
{
    public class Hotel
    {
        //Create properties for HotelId, Name, Address, City, State, Zip, Country, Phone, Email, Website, Description, Amenities, ImageUrl, Rating, Price, and IsAvailable        public int HotelId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string Rating { get; set; }
    }
}
