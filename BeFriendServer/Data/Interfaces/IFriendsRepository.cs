using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.Interfaces
{
    public interface IFriendsRepository 
    {
        List<Friends> GetFriends(string user, bool tracked);
        List<Friends> GetAll(bool tracked);
        void AddFriend(string user, string friend);
        void RemoveFriend(string user, string friend);
    }
}
