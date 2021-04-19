using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class Event
    {
        public Event()
        {
            InterestsEvents = new HashSet<InterestsEvent>();
            Participants = new HashSet<Participant>();
        }

        public int EventId { get; set; }
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int? SeatsLimit { get; set; }
        public string Photo { get; set; }
        public string EventDate { get; set; }
        public int PeopleCount { get; set; }

        public virtual Organizer Organizer { get; set; }
        public virtual ICollection<InterestsEvent> InterestsEvents { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
