using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.Dtos.AuthenticationDtos
{
	public class ManagerRequestDto
	{
		public string HotelName { get; set; }
		public string HotelAddress { get; set; }
		public string Email { get; set; }
	}
}
