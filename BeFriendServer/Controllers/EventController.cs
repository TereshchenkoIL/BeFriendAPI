using AutoMapper;
using BeFriendServer.Data;
using BeFriendServer.DTOs.Event;
using BeFriendServer.Models;
using Microsoft.AspNetCore.Http;
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
    public class EventController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public EventController(IRepositoryManager manager, IMapper mapper)
        {
            _repositoryManager = manager;
            _mapper = mapper;
        }



        [HttpGet("{id}", Name = "GetEventById")]
        public ActionResult<EventReadDTO> GetEventById(int id)
        {
            var _eventRepo = _repositoryManager.Events;
            Event item = _eventRepo.FindByCondition(x => x.EventId == id, false).Include(x => x.InterestsEvents).ThenInclude(x => x.Interest).FirstOrDefault();

            if (item != null)
            {
                return Ok(_mapper.Map<EventReadDTO>(item));
            }
            else
                return NotFound();
        }

        [HttpGet("all", Name = "GetAllEvents")]
        public ActionResult<EventReadDTO> GetAllEvents()
        {
            var _eventRepo = _repositoryManager.Events;
            List<Event> items = _eventRepo.FindAll(false).Include(x => x.InterestsEvents).ThenInclude(x => x.Interest).ToList();

            if (items != null)
            {
                return Ok(_mapper.Map<List<EventReadDTO>>(items));
            }
            else
                return NotFound();
        }
    }
}

