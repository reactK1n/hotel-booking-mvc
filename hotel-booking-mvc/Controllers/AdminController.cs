using hotel_booking_model;
using hotel_booking_model.commons;
using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_model.ViewModels;
using hotel_booking_mvc.CustomAuthorization;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers.Admin
{
   // [CustomAuthenticationFilter(roles: new string[] { "Admin" })]
    public class AdminController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IAdminService _adminService;
        private readonly IManagerService _managerService;

        public AdminController(IHotelService hotelService, IAdminService adminService,
            IManagerService managerService)
        {
            _hotelService = hotelService;
            _adminService = adminService;
            _managerService = managerService;
        }

        public async Task<IActionResult> Dashboard()
        {
            var result = await _adminService.ShowAdminDashboard();
            return View(result);
        }


        public async Task<IActionResult> HotelAsync(int pageNumber)
        {
            var hotelList = await _hotelService.GetAllHotelAsync(pageNumber);
            return View(hotelList);
        }


        public IActionResult Manager()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Transactions(int pageNumber, int pageSize)
        {
            var transactions = await _adminService.GetAllTransactions(pageSize, pageNumber);
            return View(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> Transactions(int pageNumber, int pageSize, string searchQuery)
        {
            var transactions = await _adminService.GetAllTransactions(pageSize, pageNumber, searchQuery);
            return View(transactions);
        }

        public IActionResult HotelRooms()
        {
            return View();
        }

        public async Task<IActionResult> AllManagers(string managerId, int? pageNumber)
        {
            List<PaginationResponse<IEnumerable<ManagerModel>>> AllManagers = new List<PaginationResponse<IEnumerable<ManagerModel>>>();
            if (AllManagers.Count <= 0)
            {
                var response = await _managerService.GetAllManagersAsync(pageNumber);
                if (response != null)
                {
                    AllManagers.Add(response);
                    ViewBag.SingleManager = null;
                    var singleManager = response.PageItems.FirstOrDefault(x => x.ManagerId == managerId);
                    ViewBag.SingleManager = singleManager ??= response.PageItems.FirstOrDefault();
                    return View(response);
                }

            }
            else if (AllManagers.Count > 0)
            {
                ViewBag.SingleManager = AllManagers.FirstOrDefault(x => x.PageItems.Any(x => x.ManagerId == managerId));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AllManagers(string managerId, int? pageNumber, SearchViewModel search = null)
        {
            List<PaginationResponse<IEnumerable<ManagerModel>>> AllManagers = new List<PaginationResponse<IEnumerable<ManagerModel>>>();
            PaginationResponse<IEnumerable<ManagerModel>> response = null;
            if (AllManagers.Count <= 0)
            {
                response = await _managerService.GetAllManagersAsync(pageNumber);

                if (string.IsNullOrWhiteSpace(search.SearchQuery))
                {
                    ViewBag.SingleManager = response.PageItems.FirstOrDefault();
                    return View(response);
                }

                if (response != null)
                {
                    AllManagers.Add(response);
                    ViewBag.SingleManager = null;

                    var managers = response.PageItems;
                    var filteredManagers = managers.Where(m => m.FirstName.ToLower().Contains(search.SearchQuery.ToLower())
                                                || m.LastName.ToLower().Contains(search.SearchQuery.ToLower())
                                                || m.ManagerEmail.ToLower().Contains(search.SearchQuery.ToLower()));

                    if (filteredManagers.Count() <= 0)
                    {
                        ViewBag.SingleManager = response.PageItems.FirstOrDefault();
                        return View(response);
                    }

                    response.PageItems = filteredManagers;

                    ViewBag.SingleManager = response.PageItems.FirstOrDefault();
                    return View(response);
                }
                return View();
            }
            else if (AllManagers.Count > 0)
            {
                ViewBag.SingleManager = AllManagers.FirstOrDefault(x => x.PageItems.Any(x => x.ManagerId == managerId));
                return View(response);
            }

            return View(response);
        }

        public IActionResult AllUsers()
        {
            return View();
        }
        public async Task<IActionResult> HotelDetails(string hotelId)
        {
            var singleHotel = await _hotelService.GetHotelById(hotelId);
            ViewData["GetHotel"] = singleHotel;
            return View();
        }


        public IActionResult Account()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Account(UserDto userDto)
        {
            return View();
        }

        public IActionResult AllManagersRequests()
        {
            return View();
        }
    }
}
