using hotel_booking_model.Dtos.TransactionsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hotel_booking_model.Dtos;
using hotel_booking_model.ViewModels;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminDashboardViewModel> ShowAdminDashboard();
        Task<AdminStatisticsDto> GetAdminStatistics();
        Task<TransactionsResponseDto> GetAllTransactions(int pageSize = 10, int pageNumber = 1, string searchQuery = null);
    }
}
