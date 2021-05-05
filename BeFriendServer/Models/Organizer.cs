using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class Organizer
    {
        public int EventId { get; set; }
        public string TelephoneNumber { get; set; }

        [JsonIgnore]
        public virtual Event Event { get; set; }
        [JsonIgnore]
        public virtual User TelephoneNumberNavigation { get; set; }
    }
}
