using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class Participant
    {
        public string TelephoneNumber { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual User TelephoneNumberNavigation { get; set; }
    }
}
