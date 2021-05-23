using AutoMapper;
using BeFriendServer.Data;
using BeFriendServer.DTOs.User;
using BeFriendServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFriendServer.DTOs.Interest;

namespace BeFriendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        
        public UserController(IRepositoryManager manager, IMapper mapper)
        {
            _repository = manager;
            _mapper = mapper;
        }

        // GET api/user/{num}
        [HttpGet("{num}", Name ="GetUserByNumber")]
        public ActionResult<UserReadDTO> GetUserByNumber(string num)
        {
            var _userRepo = _repository.Users;
            User user = _userRepo.GetByNumber(num);

            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDTO>(user));
            }
            else
                return NotFound();
        }
        // GET api/user/all
        [HttpGet("all", Name = "GetAllUsers")]
        public ActionResult<UserReadDTO> GetAllUsers()
        {
            var _userRepo = _repository.Users;
           List<User> users = _userRepo.GetAllUsers();

            if (users != null)
            {
                return Ok(_mapper.Map<List<UserReadDTO>>(users));
            }
            else
                return NotFound();
        }

        // POST api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDTO user)
        {
            if(user == null)
            {
                // ToDo Log this
            }
            List<InterestsUser> interests = new List<InterestsUser>();

            foreach(var interest in user.Interests)
            {
                interests.Add(new InterestsUser {TelephoneNumber = user.TelephoneNumber, InterestId = interest.InterestId });
            }
            var userEntity = _mapper.Map<User>(user);
            userEntity.InterestsUsers = interests;
            _repository.Users.CreateUser(userEntity);
            _repository.Save();

            var userReadDto = _mapper.Map<UserReadDTO>(userEntity);

            return CreatedAtRoute(nameof(GetUserByNumber), new { num = userReadDto.TelephoneNumber }, userReadDto);

        }


        // POST api/user/addInterests/{num}
        [HttpPost("addInterests/{num}")]
        public IActionResult AddInterests(string num, [FromBody] List<InterestDTO> interests)
        {
            User user = _repository.Users.GetByNumber(num, true);
            if (user == null) return NotFound();

            List<Interest> newInterest = _mapper.Map<List<Interest>>(interests);

            _repository.Users.AddInterests(user, newInterest);
            _repository.Save();
            return NoContent();
        }


        // POST api/user/addInterests/{num}
        [HttpPost("Interests/{num}")]
        public IActionResult AddInterest(string num, [FromBody] InterestDTO interest)
        {
            User user = _repository.Users.GetByNumber(num, true);
            if (user == null) return NotFound();

            Interest newInterest = _mapper.Map<Interest>(interest);

            _repository.Users.AddInterest(user, newInterest);
            _repository.Save();
            return NoContent();
        }

        // DELETE api/user/Interests/{num}
        [HttpDelete("Interests/{num}")]
        public IActionResult RemoveInterest(string num, [FromBody] InterestDTO interestDto)
        {

            User user = _repository.Users.GetByNumber(num, true);
            if (user == null) return NotFound();
            InterestsUser iu = user.InterestsUsers.Where(x => x.InterestId == interestDto.InterestId).FirstOrDefault();

            if (iu == null) return NotFound();

            user.InterestsUsers.Remove(iu);
            _repository.Save();
            return NoContent();
            
        }

        // PUT api/user/{num}

        [HttpPut("{num}")]
        public IActionResult UpdateUser(string num,[FromBody] UserUpdateDTO userUpdateDto)
        {
            if (userUpdateDto == null)
            {
                // ToDo Log this
            }
            User userFromRepo = _repository.Users.GetByNumber(num,true);

            if (userFromRepo == null) return NotFound();

            _mapper.Map(userUpdateDto, userFromRepo);
            _repository.Users.UpdateUser(userFromRepo);
            _repository.Save();
            return NoContent();
           
        }
        // ToDo Patch interesrt-User
        // PATCH api/user/{num}
        [HttpPatch("{num}")]
        public ActionResult PartialUserUpdate(string num, JsonPatchDocument<UserUpdateDTO> patchDoc)
        {
            var _repo = _repository.Users;

            var userModelFromRepo = _repository.Users.GetByNumber(num, true) ;

            if (userModelFromRepo == null) return NotFound();

            var commandToPatch = _mapper.Map<UserUpdateDTO>(userModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            //if (!TryValidateModel(commandToPatch))
            //{
            //    return ValidationProblem(ModelState);
            //}
            _mapper.Map(commandToPatch, userModelFromRepo);
            userModelFromRepo.InterestsUsers.Clear();
            foreach(Interest interest in commandToPatch.Interests )
            {
                userModelFromRepo.InterestsUsers.Add(new InterestsUser { InterestId = interest.InterestId, TelephoneNumber = num, Interest = interest });
            }

            _repo.UpdateUser(userModelFromRepo);
            _repository.Save();
            return NoContent();
        }

        // DELETE api/user/{num}
        [HttpDelete("{num}")]
        public ActionResult DeleteUser(string num)
        {
            User userFromRepo = _repository.Users.GetByNumber(num,true);
            if (userFromRepo == null) return NotFound();

            _repository.Users.DeleteUser(userFromRepo);
            _repository.Save();
            return NoContent();
        }

    }
}
