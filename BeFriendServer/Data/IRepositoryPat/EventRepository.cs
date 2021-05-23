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
            return FindAll(tracked).Include(x => x.InterestsEvents).ThenInclude(x => x.Interest).Include(x => x.Organizers).ToList();
        }

        public Event GetById(int id, bool tracked = false)
        {
            return FindByCondition(x => x.EventId == id, tracked).Include(x => x.InterestsEvents).ThenInclude(x => x.Interest).Include(x => x.Organizers).FirstOrDefault();
        }

        public void UpdateEvent(Event e)
        {
            Update(e);
        }
        public void AddInterests(Event e, List<Interest> interests)
        {

            foreach(var interest in interests)
            {
                if(e.InterestsEvents.Where(x => x.InterestId == interest.InterestId).FirstOrDefault() == null)
                {
                    e.InterestsEvents.Add(new InterestsEvent() { 
                    InterestId = interest.InterestId,
                    EventId = e.EventId
                    });
                }
            }
        }

        public void AddInterest(Event e, Interest interest)
        {

                if (e.InterestsEvents.Where(x => x.InterestId == interest.InterestId).FirstOrDefault() == null)
                {
                    e.InterestsEvents.Add(new InterestsEvent()
                    {
                        InterestId = interest.InterestId,
                        EventId = e.EventId
                    });
                }
        }

        public void AddOrginizer(Event e, string num)
        {
            if(e.Organizers.Where(x => x.TelephoneNumber == num).FirstOrDefault() == null)
            {
                e.Organizers.Add(new Organizer
                {
                    EventId = e.EventId,
                    TelephoneNumber = num
                });
            }
        }
    }
}
