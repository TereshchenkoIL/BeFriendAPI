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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Http;
using BeFriendServer.SearchEngine;
using BeFriendServer.SearchEngine.Options;

namespace BeFriendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IUserMatcher _matcher;
        private readonly IWebHostEnvironment _appEnvironment;

        public UserController(IRepositoryManager manager, IMapper mapper, IWebHostEnvironment appEnvironment, IUserMatcher matcher)
        {
            _repository = manager;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            _matcher = matcher;
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

        // GET api/user/login/{log}
        [HttpGet("login/{log}")]
        public IActionResult FindByLog(string log)
        {
            var res = _repository.Users.GetAllUsers().Where(x => x.Login.ToLower().Contains(log.ToLower())).ToList() ;
            if (res == null) return NotFound();
            return Ok(_mapper.Map<List<UserReadDTO>>(res));
        }

        // POST api/user/socials/{num}
        [HttpPost("socials/{num}")]
        public IActionResult AddSocials(string num, [FromBody] Socials socials)
        {
            User user = _repository.Users.GetByNumber(num, false);

            if (user == null) return NotFound();

            _repository.Socials.AddSocials(socials);
            _repository.Save();
            return Ok(NoContent());


        }
        // GET api/user/socials/{num}
        [HttpGet("socials/{num}")]
        public IActionResult GetSocials(string num)
        {
            User user = _repository.Users.GetByNumber(num, false);

            if (user == null) return NotFound();

            var res = _repository.Socials.GetSocials(num,false);
            if (res == null) return NotFound();

            return Ok(res);

        }

        // GET api/user/byToken/{token}
        [HttpGet("byToken/{token}")]
        public IActionResult GetBytoken(string token)
        {
            var res = _repository.Socials.GetAll(false).Where(x => x.Token == token).FirstOrDefault();

            if (res == null) return NotFound();

            return Ok(_repository.Users.GetByNumber(res.Telephone_number));

        }


        // GET api/user/recommendation/{num}
        [HttpGet("recommendation/{num}")]
        public IActionResult GetRecommendation(string num)
        {
            User user = _repository.Users.GetByNumber(num);
            if (user == null) return NotFound();

            var results = _matcher.GetRecommendation(user);
            return Ok(results);
        }

        // POST api/user/search/{num}
        [HttpPost("search/{num}")]
        public IActionResult SearchPotentials(string num, [FromBody] UserSearchOptions options)
        {
            User user = _repository.Users.GetByNumber(num);
            if (user == null) return NotFound();

            var results = _matcher.Match(user,options);
            return Ok(results);
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

        // POST api/user/photo/{num}
        [HttpPost("photo/{num}")]
        public async Task<IActionResult> SetPhoto(string num )
        {
            User user = _repository.Users.GetByNumber(num, true);

            if (user == null) return NotFound();
            string oldFile = Path.Combine(_appEnvironment.ContentRootPath, _appEnvironment.WebRootPath, "images/" + user.Photo);

            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }

            var file = Request.Form.Files[0]; 
            string fName = user.Login + "_" + Guid.NewGuid() + Path.GetExtension(file.FileName);
            user.Photo = fName;
            string path = Path.Combine(_appEnvironment.ContentRootPath, _appEnvironment.WebRootPath, "images/" + fName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _repository.Save();
            return NoContent();
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
