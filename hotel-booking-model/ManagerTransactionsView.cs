using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model
{
    public class ManagerTransactionsView
    {
        public string BookingId { get; set; }
        public string BookingReference { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string ServiceName { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool PaymentStatus { get; set; }
        public string PayementMethod { get; set; }
        public decimal Commission { get; set; }
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public string CustomerName { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
