using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers
{
    public class LandingViewController : Controller
    {
        private readonly IHotelService _hotelService;

        public LandingViewController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }




        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var hotels = await _hotelService.GetTopHotelsAsync();
            return View(hotels);
        }

    }
}
