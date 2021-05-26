using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Models
{
    public class Friends
    {
        public String FirstNumber { get; set; }
        public String SecondNumber { get; set; }

        [ForeignKey("FirstNumber")]
        public User User { get; set; }

        [ForeignKey("SecondNumber")]
        public User Friend { get; set; }
    }
}
