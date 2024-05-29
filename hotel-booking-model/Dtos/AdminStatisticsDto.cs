using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.Dtos
{
    public class AdminStatisticsDto
    {
        public int TotalNumberOfHotels { get; set; }
        public decimal TotalMonthlyTransactions { get; set; }
        public ICollection<string> Managers { get; set; }
        public decimal Commission { get; set; }
        public decimal TotalMonthlyCommission { get; set; }
        public Dictionary<string, decimal> AnnualRevenue { get; set; }
    }
}
