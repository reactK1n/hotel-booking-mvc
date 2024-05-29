﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.Dtos.AuthenticationDtos
{
    public class AuthenticatedDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string FullName { 
            get { return FirstName + " " +  LastName; }
        }
    }
}
