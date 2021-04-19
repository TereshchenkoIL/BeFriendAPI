﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class Interest
    {
        public Interest()
        {
            InterestsEvents = new HashSet<InterestsEvent>();
            InterestsUsers = new HashSet<InterestsUser>();
        }

        public int InterestId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InterestsEvent> InterestsEvents { get; set; }
        public virtual ICollection<InterestsUser> InterestsUsers { get; set; }
    }
}
