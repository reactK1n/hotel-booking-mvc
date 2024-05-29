using hotel_booking_model.Dtos;
using System.Collections.Generic;

namespace hotel_booking_model.ViewModels
{
    public class ManagerDashboardViewModel
    {
        public ManagerStatisticDto Statistics { get; set; }
        public IEnumerable<CustomerViewModel> TopCustomers { get; set; }

        public ManagerDashboardViewModel(ManagerStatisticDto statisticDto, IEnumerable<CustomerViewModel> topCustomer)
        {
            Statistics = statisticDto;
            TopCustomers = topCustomer;
        }
    }
}
