﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class User
    {
        public User()
        {
            InterestsUsers = new HashSet<InterestsUser>();
            Participants = new HashSet<Participant>();
        }

        public string TelephoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public byte Sex { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public int? CommunicationsCount { get; set; }
        public byte IsAdmin { get; set; }

        [JsonIgnore]
        public virtual Message Message { get; set; }
        [JsonIgnore]
        public virtual Notification Notification { get; set; }
        [JsonIgnore]
        public virtual Organizer Organizer { get; set; }
        [JsonIgnore]
        public virtual Payment Payment { get; set; }
        [JsonIgnore]
        public virtual ICollection<InterestsUser> InterestsUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Participant> Participants { get; set; }
        [JsonIgnore]
        public virtual ICollection<Organizer> Organizers { get; set; }
    }
}
