using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class Organizer
    {
        public int EventId { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual Event Event { get; set; }
        public virtual User TelephoneNumberNavigation { get; set; }
    }
}
