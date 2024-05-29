using System.Collections.Generic;

namespace hotel_booking_model
{
    public class HotelDetailsViewDTo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FeaturedImage { get; set; }
        public IList<string> Gallery { get; set; }
        public IList<Roomtype> RoomTypes { get; set; }
        public IList<Amenity> Amenities { get; set; }
        public IList<Review> Reviews { get; set; }

       
        public class Roomtype
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public decimal Discount { get; set; }
            public string Thumbnail { get; set; }
        }

        public class Room
        {
            public string RoomTypeId { get; set; }
            public string RoomNo { get; set; }
            public bool IsBooked { get; set; }
            public Roomtype Roomtype { get; set; }
        }

        public class Amenity
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Discount { get; set; }
        }

        public class Review
        {
            public string Text { get; set; }
            public string CustomerImage { get; set; }
            public string Date { get; set; }
        }
    }
}
