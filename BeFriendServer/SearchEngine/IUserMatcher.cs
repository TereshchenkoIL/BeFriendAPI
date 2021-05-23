using BeFriendServer.Models;
using BeFriendServer.SearchEngine.Options;
using BeFriendServer.SearchEngine.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.SearchEngine
{
    interface IUserMatcher
    {
        List<UserSearchResult> Match(User client, UserSearchOptions options);
        List<UserSearchResult> GetRecommendation(User user);
    }
}
