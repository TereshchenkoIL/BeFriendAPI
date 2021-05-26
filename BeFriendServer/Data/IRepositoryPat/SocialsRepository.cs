using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.IRepositoryPat
{
    public class SocialsRepository : RepositoryBase<Socials>, ISocialsRepository
    {
        public SocialsRepository(befrienddbContext context)
           : base(context)
        {

        }
        public void AddSocials( Socials socials)
        {
            Create(socials);
        }

      

        public List<Socials> GetAll(bool tracked)
        {
            return FindAll(tracked).ToList();
        }

        public List<Socials> GetSocials(string num, bool tracked)
        {
            return FindByCondition(x => x.Telephone_number == num, tracked).ToList();
        }
    }
}
