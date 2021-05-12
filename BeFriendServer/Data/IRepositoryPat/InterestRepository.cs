using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data
{
    public class InterestRepository : RepositoryBase<Interest>, IInterestRepository
    {
        public InterestRepository(befrienddbContext context)
            :base(context)
        {

        }

        public void CreateInterest(Interest interest)
        {
            Create(interest);
        }

        public void DeleteInterest(Interest interest)
        {
            Delete(interest);
        }

        public List<Interest> GetAll(bool tracked = true)
        {
            return FindAll(tracked).ToList();
        }

        public Interest GetById(int id, bool tracked = true)
        {
            return FindByCondition(x => x.InterestId == id, tracked).FirstOrDefault();
        }

        public void UpdateInterest(Interest interest)
        {
            Update(interest);
        }
    }
}
