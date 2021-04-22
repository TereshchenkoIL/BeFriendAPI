using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
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
    }
}
