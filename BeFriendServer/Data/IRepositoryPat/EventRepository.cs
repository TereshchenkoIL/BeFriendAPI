using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(befrienddbContext context)
            :base(context)
        {

        }

        public void CreateEvent(Event e)
        {
            Create(e);
        }

        public void DeleteEvent(Event e)
        {
            Delete(e);
        }

        public List<Event> GetAll(bool tracked = false)
        {
            return FindAll(tracked).Include(x => x.InterestsEvents).ThenInclude(x => x.Interest).ToList();
        }

        public Event GetById(int id, bool tracked = false)
        {
            return FindByCondition(x => x.EventId == id, tracked).Include(x => x.InterestsEvents).ThenInclude(x => x.Interest).FirstOrDefault();
        }

        public void UpdateEvent(Event e)
        {
            Update(e);
        }
    }
}
