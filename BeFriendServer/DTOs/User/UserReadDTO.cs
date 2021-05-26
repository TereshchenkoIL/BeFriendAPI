using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFriendServer.Models;

namespace BeFriendServer.DTOs.User
{
    public class UserReadDTO
    {
        public string TelephoneNumber { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public int? CommunicationsCount { get; set; }

        public List<Models.Interest> Interests { get; set; }
    }
}
