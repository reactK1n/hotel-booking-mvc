namespace hotel_booking_model
{
    public class HotelBasicView
    {        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Rating { get; set; }        
        public int NumberOfReviews { get; set; }
        public string Comment { get => (Rating > 7) ? "Good" : "Average"; }
        public string FeaturedImage { get; set; }
        public string ManagerId { get; set; }
    }
}
