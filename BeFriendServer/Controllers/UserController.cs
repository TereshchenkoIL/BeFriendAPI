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

namespace BeFriendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        
        public UserController(IRepositoryManager manager, IMapper mapper)
        {
            _repositoryManager = manager;
            _mapper = mapper;
        }

        // GET api/user/{num}
        [HttpGet("{num}", Name ="GetUserByNumber")]
        public ActionResult<UserReadDTO> GetUserByNumber(string num)
        {
            var _userRepo = _repositoryManager.Users;
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
            var _userRepo = _repositoryManager.Users;
           List<User> users = _userRepo.GetAllUsers();

            if (users != null)
            {
                return Ok(_mapper.Map<List<UserReadDTO>>(users));
            }
            else
                return NotFound();
        }

        // ToDo Patch interesrt-User
        // PATCH api/user/{num}
        [HttpPatch("{num}")]
        public ActionResult PartialUserUpdate(string num, JsonPatchDocument<UserUpdateDTO> patchDoc)
        {
            var _repo = _repositoryManager.Users;

            var userModelFromRepo = _repositoryManager.Users.GetByNumber(num, true) ;

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
            _repositoryManager.Save();
            return NoContent();
        }

    }
}
