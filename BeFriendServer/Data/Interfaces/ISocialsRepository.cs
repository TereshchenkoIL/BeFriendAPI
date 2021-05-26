using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.Interfaces
{
    public interface ISocialsRepository
    {
        void AddSocials(Socials socials);

        List<Socials> GetAll(bool tracked);

        List<Socials> GetSocials(string num ,bool tracked);


    }
}
