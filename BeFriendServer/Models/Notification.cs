using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class Notification
    {
        public int NotificationsId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string TelephoneNumber { get; set; }
        public string Image { get; set; }

        public virtual User TelephoneNumberNavigation { get; set; }
    }
}
