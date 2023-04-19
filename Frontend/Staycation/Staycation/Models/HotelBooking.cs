namespace Staycation.Models
{
    public class HotelBooking
    {
        //add properties for hotel booking reservation
        
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelImage { get; set; }
        public string HotelPrice { get; set; }
        public string HotelRating { get; set; }
        public string HotelDescription { get; set; }
        public string HotelId { get; set; }
        public string UserId { get; set; }
        public string BookingId { get; set; }
        public string BookingDate { get; set; }
        public string BookingStatus { get; set; }
        public string BookingTotal { get; set; }
        public string BookingTotalNights { get; set; }
        public string BookingGuests { get; set; }
        public string BookingRooms { get; set; }
        public string BookingPaymentType { get; set; }
        public string BookingPaymentStatus { get; set; }
    }
}
