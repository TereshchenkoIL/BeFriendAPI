using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetByNumber(string num, bool tracked = false);
        List<User> GetAllUsers(bool tracked = false);
        void CreateUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        public void AddInterests(User user, List<Interest> interests);
        public void AddInterest(User user, Interest interest);

    }
}
