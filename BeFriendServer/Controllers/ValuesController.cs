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

    public class ValuesController : ControllerBase
    {
        private readonly befrienddbContext _context;

        public ValuesController(befrienddbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetTodoItem(string id)
        {
            var todoItem = await _context.Users.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}
