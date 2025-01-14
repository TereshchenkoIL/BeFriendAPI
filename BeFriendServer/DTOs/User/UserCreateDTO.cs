﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.DTOs.User
{
    public class UserCreateDTO
    {
        public string TelephoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int? CommunicationsCount { get; set; }
        public byte IsAdmin { get; set; }
        public List<Models.Interest> Interests { get; set; }
    }
}
