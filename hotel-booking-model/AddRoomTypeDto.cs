using Microsoft.AspNetCore.Http;

namespace hotel_booking_model
{
    public class AddRoomTypeDto
    {
        public IFormFile Image { get; set; }
        public string RoomName { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
