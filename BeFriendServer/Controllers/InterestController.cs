using AutoMapper;
using BeFriendServer.Data;
using Microsoft.AspNetCore.Hosting;
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
    public class InterestController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public InterestController(IRepositoryManager manager, IMapper mapper)
        {
            _repository = manager;
            _mapper = mapper;

        }
        
        // GET api/interest/all
        [HttpGet("all")]
        public IActionResult GetAllInterests()
        {
            return Ok(_repository.Interests.GetAll());
        }

    }
}
