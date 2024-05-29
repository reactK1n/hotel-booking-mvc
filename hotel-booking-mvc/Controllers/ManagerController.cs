
﻿using hotel_booking_model;
using hotel_booking_model.ViewModels;
using hotel_booking_mvc.CustomAuthorization;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using hotel_booking_model.Dtos.AuthenticationDtos;
using Newtonsoft.Json;


using Microsoft.AspNetCore.Authorization;

namespace hotel_booking_mvc.Controllers.Manager
{
    //[CustomAuthenticationFilter(roles: new string[] { "Manager" })]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IHotelService _hotelService;
        


        public ManagerController(IHotelService hotelService, IManagerService managerService)

        {
          
            _hotelService = hotelService;
            _managerService = managerService;
        }

        public async Task<IActionResult> DashboardAsync()
        {
            var loggedinUser = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<AuthenticatedDto>(loggedinUser);
            var result = await _managerService.ShowManagerDashboard(user.Id);
            return View(result);
        }

        public async Task<IActionResult> HotelAsync()
        {

            var loggedinUser = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<AuthenticatedDto>(loggedinUser);
            var paginationResponse = await _hotelService.GetAllHotelForManagerAsync(user.Id);
            return View(paginationResponse);
        }

        public IActionResult Bookings()
        {
            return View();
        }

       [HttpGet]
        public async Task<IActionResult> Transactions(int pageNumber, int pageSize)
        {

            var loggedinUser = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<AuthenticatedDto>(loggedinUser);


            var managerTransactionsList = await _managerService.GetAllManagerTransactionsAsync(user.Id, pageSize, pageNumber);
            return View(managerTransactionsList);
        }
        [HttpPost]
        public async Task<IActionResult> Transactions(int pageNumber, int pageSize, string searchQuery)
        {

            var loggedinUser = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<AuthenticatedDto>(loggedinUser);

            var managerTransactionsList = await _managerService.GetAllManagerTransactionsAsync(user.Id, pageSize, pageNumber, searchQuery);
            return View(managerTransactionsList);
        }
        public async Task<IActionResult> HotelRooms(string roomTypeId)
        {
            var result = await _hotelService.GetRoomTypeDetails(roomTypeId);
            return View(result);
        }

        public async Task<IActionResult> HotelDetails(string hotelId)
        {
            var singleHotel = await _hotelService.GetHotelById(hotelId);
            var customers = await _hotelService.GetHotelCustomersAsync(hotelId);
            ViewData["GetHotel"] = singleHotel;
            ViewData["Customers"] = customers;
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


        [AllowAnonymous]
        public IActionResult RegisterManager()
        {
            return View();
        }
    }
}
