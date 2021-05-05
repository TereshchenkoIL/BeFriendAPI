using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Content { get; set; }
        public string Messagescol { get; set; }
        public string TelephoneNumber { get; set; }
        [JsonIgnore]
        public virtual Chat Chat { get; set; }
        [JsonIgnore]
        public virtual User TelephoneNumberNavigation { get; set; }
    }
}
