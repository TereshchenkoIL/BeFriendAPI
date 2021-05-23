using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.SearchEngine.Options
{
    public class UserSearchOptions
    {
        public List<Interest> Interests { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string Sex { get; set; }
    }
}
