using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(befrienddbContext context)
            :base(context)
        {

        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public List<User> GetAllUsers(bool tracked = false)
        {
           return FindAll(tracked).Include(x => x.InterestsUsers).ThenInclude(x => x.Interest).ToList();
        }

        public User GetByNumber(string num, bool tracked = false)
        {
           return FindByCondition(x => x.TelephoneNumber.Equals(num), tracked).Include(x => x.InterestsUsers).ThenInclude(x => x.Interest).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
