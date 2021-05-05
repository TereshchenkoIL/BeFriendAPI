using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace BeFriendServer.Models
{
    public partial class Chat
    {
        public int ChatId { get; set; }
        public DateTime CreationDate { get; set; }
        [JsonIgnore]
        public virtual Message Message { get; set; }
    }
}
