using AutoMapper;
using BeFriendServer.Data;
using BeFriendServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FriendsController(IRepositoryManager manager, IMapper mapper)
        {
            _repository = manager;
            _mapper = mapper;
           
        }


        // POST api/friends/add/{num1}/{num2}
        [HttpPost("add/{num1}/{num2}")]
        public IActionResult AddFriends(string num1, string num2)
        {
            _repository.Friends.AddFriend(num1, num2);
            _repository.Save();

            return Ok(NoContent());
        }

        // POST api/friends/remove/{num1}/{num2}
        [HttpPost("remove/{num1}/{num2}")]
        public IActionResult RemoveFriends(string num1, string num2)
        {
            _repository.Friends.AddFriend(num1, num2);
            _repository.Save();

            return Ok(NoContent());
        }

        // GET api/friends/{num}
        [HttpGet("{num}")]
        public IActionResult GetFriends(string num)
        {
            User user = _repository.Users.GetByNumber(num);
            if (user == null) return NotFound();

            var res = _repository.Friends.GetFriends(num, false);

            if (res == null) return NotFound();

            List<User> users = new List<User>();

            foreach(var item in res)
            {
                users.Add(_repository.Users.GetByNumber(item.SecondNumber));
            }

            return Ok(users);
        }

        // GET api/friends/all
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_repository.Friends.GetAll(false));
        }
    }
}
