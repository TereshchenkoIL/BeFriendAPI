using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class InterestsUser
    {
        public int InterestId { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual Interest Interest { get; set; }
        public virtual User TelephoneNumberNavigation { get; set; }
    }
}
