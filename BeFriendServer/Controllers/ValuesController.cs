using BeFriendServer.Data;
using BeFriendServer.Data.Interfaces;
using BeFriendServer.DTOs.User;
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

    public class ValuesController : ControllerBase
    {
        private readonly IRepositoryManager _repo;

        public ValuesController(IRepositoryManager repo)
        {
            _repo = repo;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetTodoItem(string id)
        {
            UserRepository user = (UserRepository)_repo.Users;
            User todoItem = user.FindByCondition(x => x.TelephoneNumber == id, false).FirstOrDefault();
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}
