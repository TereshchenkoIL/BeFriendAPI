using BeFriendServer.Models;
using BeFriendServer.SearchEngine.Options;
using BeFriendServer.SearchEngine.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.SearchEngine
{
    public interface IEventMatcher
    {
        List<EventSearchResult> getRecommendation(User user);
        public List<EventSearchResult> Match(EventSearchOptions options, User client);
    }
}
