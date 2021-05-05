using AutoMapper;
using BeFriendServer.Data;
using BeFriendServer.DTOs.User;
using BeFriendServer.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{num}", Name ="GetUserByNumber")]
        public ActionResult<UserReadDTO> GetUserByNumber(string num)
        {
            var _userRepo = _repositoryManager.Users;
            User user = _userRepo.FindByCondition(x => x.TelephoneNumber.Equals(num),false).Include(x=>x.InterestsUsers).ThenInclude(x=>x.Interest).FirstOrDefault();

            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDTO>(user));
            }
            else
                return NotFound();
        }
    }
}
