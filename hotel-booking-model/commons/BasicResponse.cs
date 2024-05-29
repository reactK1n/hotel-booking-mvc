using System.Security.Claims;

namespace hotel_booking_model.commons
{
    public class BasicResponse<TRes> where TRes : class
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public TRes Data { get; set; }
        public Claim Claim { get; set; }
    }
}
