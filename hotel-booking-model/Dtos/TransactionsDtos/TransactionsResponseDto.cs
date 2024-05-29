using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.Dtos.TransactionsDtos
{
    public class TransactionsResponseDto
    {
        public Data data { get; set; }
        public bool succeeded { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

    public class Data
    {
        public ICollection<Pageitem> pageItems { get; set; }
        public int pageSize { get; set; }
        public int currentPage { get; set; }
        public int numberOfPages { get; set; }
        public int previousPage { get; set; }
    }

    public class Pageitem
    {
        public string bookingId { get; set; }
        public string bookingReference { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public string serviceName { get; set; }
        public decimal paymentAmount { get; set; }
        public string paymentStatus { get; set; }
        public string paymentMethod { get; set; }
        public decimal commission { get; set; }
        public string hotelId { get; set; }
        public string hotelName { get; set; }
        public string customerName { get; set; }
        public DateTime paymentDate { get; set; }
        public DateTime createdAt { get; set; }
    }

}
