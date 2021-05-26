using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.IRepositoryPat
{
    public class FriendsRepository : RepositoryBase<Friends>, IFriendsRepository
    {
        public FriendsRepository(befrienddbContext context)
            : base(context)
        {

        }
        public void AddFriend(string user, string friend)
        {
            Create(new Friends { FirstNumber = user, SecondNumber = friend });
            Create(new Friends { FirstNumber = friend, SecondNumber = user });
        }

        public List<Friends> GetAll(bool tracked)
        {
            return FindAll(tracked).ToList();
        }

        public List<Friends> GetFriends(string user, bool tracked)
        {
            return FindByCondition(x => x.FirstNumber == user, tracked).ToList();
        }

       

        public void RemoveFriend(string user, string friend)
        {
            foreach(var f in FindAll(true))
            {
                if((f.FirstNumber == user && f.SecondNumber == friend) || (f.FirstNumber == friend && f.SecondNumber ==user))
                {
                    Delete(f);
                }
            }
        }
    }
}
