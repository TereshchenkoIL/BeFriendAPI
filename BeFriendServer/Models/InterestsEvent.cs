using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class InterestsEvent
    {
        public int InterestId { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Interest Interest { get; set; }
    }
}
