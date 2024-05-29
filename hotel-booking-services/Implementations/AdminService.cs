using hotel_booking_model.commons;
using hotel_booking_model.Dtos;
using hotel_booking_model.Dtos.TransactionsDtos;
using hotel_booking_model.ViewModels;
using hotel_booking_services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class AdminService : IAdminService
    {
        private readonly IHttpRequestFactory _httpRequestFactory;
        private readonly IHotelService _hotelService;
        public AdminService(IHttpRequestFactory httpRequestFactory, IHotelService hotelService)
        {
            _httpRequestFactory = httpRequestFactory;
            _hotelService = hotelService;
        }

        public async Task<AdminStatisticsDto> GetAdminStatistics()
        {
            var response = await _httpRequestFactory.GetRequestAsync
                <BasicResponse<AdminStatisticsDto>>(
                    requestUrl: $"api/Statistics/get-statistics/admin");

            return response.Data;
        }

        public async Task<AdminDashboardViewModel> ShowAdminDashboard()
        {
            var adminStatisticsDto = await GetAdminStatistics();
            var topHotels = await _hotelService.GetTopHotelsAsync();
            var hotelsCountPerState = await _hotelService.GetTotalHotelsPerLocation();
            var result = new AdminDashboardViewModel()
            {
                TopHotels = topHotels,
                TotalHotels = adminStatisticsDto.TotalNumberOfHotels,
                TotalManagers = adminStatisticsDto.Managers.Count,
                TotalMonthlyCommission = adminStatisticsDto.TotalMonthlyCommission,
                TotalMonthlyTransaction = adminStatisticsDto.TotalMonthlyTransactions,
                Months = adminStatisticsDto.AnnualRevenue.Select(x => x.Key).ToList(),
                Revenues = adminStatisticsDto.AnnualRevenue.Select(x => x.Value).ToList(),
                States = hotelsCountPerState.Select(x => x.Key).ToList(),
                TotalHotelsPerState = hotelsCountPerState.Select(x => x.Value).ToList()
            };
            return result;
        }

        public async Task<TransactionsResponseDto> GetAllTransactions(int pageSize = 10, int pageNumber = 1, string searchQuery = null)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var result = await _httpRequestFactory.GetRequestAsync<TransactionsResponseDto>
                (
                requestUrl: $"api/Admin/transactions?PageSize={pageSize}&PageNumber={pageNumber}&SearchQuery={searchQuery}"      
                );
            return result;
        }
    }
}
