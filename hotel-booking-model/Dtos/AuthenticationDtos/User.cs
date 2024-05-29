using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.Dtos.AuthenticationDtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}