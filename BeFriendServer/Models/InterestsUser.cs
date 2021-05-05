using Newtonsoft.Json;
using System;
using System.Collections.Generic;


#nullable disable

namespace BeFriendServer.Models
{
    public partial class InterestsUser
    {
        public int InterestId { get; set; }
        public string TelephoneNumber { get; set; }
        [JsonIgnore]
        public virtual Interest Interest { get; set; }
        [JsonIgnore]
        public virtual User TelephoneNumberNavigation { get; set; }
    }
}
