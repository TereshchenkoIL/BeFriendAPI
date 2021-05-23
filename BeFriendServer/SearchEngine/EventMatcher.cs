using BeFriendServer.Data;
using BeFriendServer.Models;
using BeFriendServer.SearchEngine.Options;
using BeFriendServer.SearchEngine.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.SearchEngine
{
    public class EventMatcher : IEventMatcher
    {
        private readonly IRepositoryManager _repository;

        public EventMatcher(IRepositoryManager manager)
        {
            _repository = manager;
        }
        private EventSearchResult Calculate(User user, Event eventModel)
        {
            int coincided = 0;
            foreach (InterestsEvent interest in eventModel.InterestsEvents)
            {
                if (user.InterestsUsers.Where(x => x.InterestId == interest.InterestId).
                    FirstOrDefault() != null)
                {
                    ++coincided;
                }
            }
            double optionsIntersection = coincided / (double)eventModel.InterestsEvents.Count();
            double userIntersection = coincided / (double)user.InterestsUsers.Count();
            double result = optionsIntersection < userIntersection ? optionsIntersection / userIntersection :
                userIntersection / optionsIntersection;

            return new EventSearchResult()
            {
                Event_Id = eventModel.EventId,
                Photo = eventModel.Photo,
                Name = eventModel.Name,
                Result = result
            };
        }
        public List<EventSearchResult> getRecommendation(User user)
        {
            List<EventSearchResult> events = new List<EventSearchResult>();

            foreach (var item in _repository.Events.GetAll())
            {
                events.Add(Calculate(user, item));
            }

            return events.Take(100).ToList();
        }
        private bool FilterInterests(Event e, List<Interest> interests)
        {
            foreach (var interest in interests)
            {
                if (e.InterestsEvents.Where(x => x.InterestId == interest.InterestId).FirstOrDefault() == null)
                {
                    return false;
                }
            }
            return true;
        }

        public List<EventSearchResult> Match(EventSearchOptions options, User client)
        {
            List<EventSearchResult> results = new List<EventSearchResult>();
            int age = DateTime.Now.Year - client.Birthday.Year;

            List<Event> events = _repository.Events.GetAll().Where(x => (x.Country == options.Country || options.Country == "All") &&
            (x.City == options.City || options.City == "All") && (options.MinAge <= age && age <= options.MaxAge)).ToList();
            if (options.Interests == null)
            {
                foreach (var e in events)
                {
                    results.Add(Calculate(client, e));
                }
                return results;
            }

            foreach (var e in events)
            {
                if (FilterInterests(e, options.Interests))
                {
                    results.Add(Calculate(client, e));
                }

            }

            return results;
        }
    }
}
