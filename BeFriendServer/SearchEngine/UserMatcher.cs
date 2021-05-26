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
    public class UserMatcher : IUserMatcher
    {
        private readonly IRepositoryManager _repository;

        public UserMatcher(IRepositoryManager manager)
        {
            _repository = manager;
        }
        private UserSearchResult Calculate(User client, User user)
        {

            int coincided = 0;
            foreach (InterestsUser interest in client.InterestsUsers)
            {
                if (user.InterestsUsers.Where(x => x.InterestId == interest.InterestId).
                    FirstOrDefault() != null)
                {
                    ++coincided;
                }
            }
            double optionsIntersection = coincided / (double)client.InterestsUsers.Count();
            double userIntersection = coincided / (double)user.InterestsUsers.Count();
            double result = optionsIntersection < userIntersection ? optionsIntersection / userIntersection :
                userIntersection / optionsIntersection;

            return new UserSearchResult()
            {
                TelephoneNumber = user.TelephoneNumber,
                LogIn = user.Login,
                Image = user.Photo,
                Result = result
            };

        }

        private bool FilterInterests(User user, List<Interest> interests)
        {
            foreach (var interest in interests)
            {
                if (user.InterestsUsers.Where(x => x.InterestId == interest.InterestId).FirstOrDefault() == null)
                {
                    return false;
                }
            }
            return true;
        }

        public List<UserSearchResult> Match(User client, UserSearchOptions options)
        {
            List<UserSearchResult> results = new List<UserSearchResult>();
            int age = client.Age;

            List<User> users = _repository.Users.GetAllUsers().Where(x => (x.Country == options.Country || options.Country == "all") &&
            (x.City == options.City || options.City == "Всі") && (options.MinAge <= age && age <= options.MaxAge) && x.TelephoneNumber != client.TelephoneNumber
            && (x.Sex == options.Sex || options.Sex == "all")).ToList();
            if (options.Interests == null)
            {
                foreach (var user in users)
                {
                    results.Add(Calculate(client, user));
                }
                return results;
            }

            foreach (var user in users)
            {
                if (FilterInterests(user, options.Interests))
                {
                    results.Add(Calculate(client, user));
                }

            }

            return results;

        }

        public List<UserSearchResult> GetRecommendation(User client)
        {
            List<UserSearchResult> results = new List<UserSearchResult>();

            foreach (var user in _repository.Users.GetAllUsers().Where(x => x.TelephoneNumber != client.TelephoneNumber))
            {
                results.Add(Calculate(client, user));
            }
            return results.OrderBy(x => x.Result).Take(100).ToList();
        }
   
    }
}
