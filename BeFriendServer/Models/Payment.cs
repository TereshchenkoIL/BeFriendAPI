using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime EndDate { get; set; }

        public virtual User TelephoneNumberNavigation { get; set; }
    }
}
