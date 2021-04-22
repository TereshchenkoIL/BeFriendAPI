using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.DTOs.Notification
{
    public class NotificationReadDTO
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public string TelephoneNumber { get; set; }
        public string Image { get; set; }
    }
}
