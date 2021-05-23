using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.SearchEngine.Results
{
    public class EventSearchResult
    {
        public int Event_Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public double Result { get; set; }
    }
}
