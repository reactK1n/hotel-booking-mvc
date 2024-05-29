using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Enter Email To Continue")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password To Continue")]
        public string Password { get; set; }
        public string Id { get; set; }
        public string Token { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
