using Microsoft.AspNetCore.Mvc;

namespace hotel_booking_mvc.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Error401()
        {
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult Error500()
        {
            return View();
        }
    }
}
