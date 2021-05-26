using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Models
{
    public class Socials
    {
        public string Social { get; set; }
        public string Telephone_number { get; set; }
        public string Token { get; set; }
        [ForeignKey("Telephone_number")]
        public User User { get; set; }
    }
}
