using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.Interfaces
{
    public interface IEventRepository 
    {
        Event GetById(int id, bool tracked = false);
        List<Event> GetAll(bool tracked = false);
        void CreateEvent(Event e);
        void DeleteEvent(Event e);
        void UpdateEvent(Event e);
        public void AddInterests(Event e, List<Interest> interests);
        public void AddInterest(Event e, Interest interest);

        public void AddOrginizer(Event e, string num);
    }
}
