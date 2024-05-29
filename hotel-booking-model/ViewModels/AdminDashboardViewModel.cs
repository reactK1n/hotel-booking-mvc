using hotel_booking_model.Dtos.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalManagers { get; set; }
        public int TotalHotels { get; set; }
        public decimal TotalMonthlyCommission { get; set; }
        public decimal TotalMonthlyTransaction { get; set; }
        public IEnumerable<HotelBasicDetailsDto> TopHotels { get; set; }
        public IEnumerable<string> Months { get; set; }
        public IEnumerable<decimal> Revenues { get; set; }
        public IEnumerable<string> States { get; set; }
        public IEnumerable<int> TotalHotelsPerState { get; set; }
    }
}
