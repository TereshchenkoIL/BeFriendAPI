using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.DTOs.Message
{
    public class MessageReadDTO
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Content { get; set; }
        public string Messagescol { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
