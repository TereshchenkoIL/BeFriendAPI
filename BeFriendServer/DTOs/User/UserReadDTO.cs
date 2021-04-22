using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.DTOs.User
{
    public class UserReadDTO
    {
        public string TelephoneNumber { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public byte Sex { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public int? CommunicationsCount { get; set; }

    }
}
