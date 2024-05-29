namespace hotel_booking_model.commons
{
	public class PaginationResponse<TRes> where TRes : class
    {
        public TRes PageItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int PreviousPage { get; set; }
    }
}
