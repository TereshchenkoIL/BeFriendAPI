using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.Interfaces
{
    public interface IInterestRepository
    {
        Interest GetById(int id, bool tracked = true);
        List<Interest> GetAll(bool tracked = true);
        void CreateInterest(Interest interest);
        void DeleteInterest(Interest interest);
        void UpdateInterest(Interest interest);
    }
}
