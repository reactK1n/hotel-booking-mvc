using hotel_booking_model;
using hotel_booking_model.commons;
using hotel_booking_model.Dtos;
using hotel_booking_model.Dtos.Hotels;
using hotel_booking_services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class HotelService : IHotelService
    {
        private readonly IHttpRequestFactory _requestFactory;

        public HotelService(IHttpRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }

        public async Task<PaginationResponse<IEnumerable<HotelBasicView>>> GetAllHotelAsync(int pageNumber)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var response = await _requestFactory.GetRequestAsync
                <BasicResponse< PaginationResponse<IEnumerable < HotelBasicView>>>>(
                    requestUrl: $"api/Hotel/all-hotels?PageSize=5&PageNumber={pageNumber}");

            return response.Data;
        }


        public async Task<IEnumerable<HotelBasicView>> GetAllHotelForManagerAsync(string managerId)
        {
            var response = await _requestFactory.GetRequestAsync
                <BasicResponse<IEnumerable<HotelBasicView>>>(
                    requestUrl: $"api/Manager/{managerId}/hotels");

            return response.Data;
        }


        public async Task<IEnumerable<HotelBasicDetailsDto>> GetTopHotelsAsync()
        {
            var response = await _requestFactory.GetRequestAsync
                <BasicResponse<IEnumerable<HotelBasicDetailsDto>>>(
                    requestUrl: $"api/Hotel/top-hotels");

            return response.Data;
        }

        public async Task<IEnumerable<HotelCustomerDTO>> GetHotelCustomersAsync(string hotelId)
        {
            var response = await _requestFactory.GetRequestAsync<BasicResponse<IEnumerable<HotelCustomerDTO>>>($"api/Hotel/{hotelId}/customers");
            return response.Data;
        }


        public async Task<Dictionary<string, int>> GetTotalHotelsPerLocation()
        {
            var response = await _requestFactory.GetRequestAsync
                <BasicResponse<Dictionary<string, int>>>(
                requestUrl: "api/Hotel/total-hotels-per-location");

            return response.Data;
		}


        public async Task<HotelDetailsViewDTo> GetHotelById(string hotelId)
        {
            var response = await _requestFactory.GetRequestAsync
                <BasicResponse<HotelDetailsViewDTo>>(
                    requestUrl: $"api/Hotel/{hotelId}");

            return response.Data;
        }

        public async Task<RoomTypeDetailsDto> GetRoomTypeDetails(string roomTypeId)
        {
            var response = await _requestFactory.GetRequestAsync
                <BasicResponse<RoomTypeDetailsDto>>(
                requestUrl: $"/api/Hotel/roomTypedetails/{roomTypeId}");
            return response.Data;
        }
    }
}
