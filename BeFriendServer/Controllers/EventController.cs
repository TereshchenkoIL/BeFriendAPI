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
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EventController(IRepositoryManager manager, IMapper mapper)
        {
            _repository = manager;
            _mapper = mapper;
        }


        // GET api/event/{id}
        [HttpGet("{id}", Name = "GetEventById")]
        public ActionResult<EventReadDTO> GetEventById(int id)
        {
            var _eventRepo = _repository.Events;
            Event item = _eventRepo.GetById(id);

            if (item != null)
            {
                return Ok(_mapper.Map<EventReadDTO>(item));
            }
            else
                return NotFound();
        }

        // GET api/event
        [HttpGet("all", Name = "GetAllEvents")]
        public ActionResult<EventReadDTO> GetAllEvents()
        {
            var _eventRepo = _repository.Events;
            List<Event> items = _eventRepo.GetAll();

            if (items != null)
            {
                return Ok(_mapper.Map<List<EventReadDTO>>(items));
            }
            else
                return NotFound();
        }


        // POST api/event
        [HttpPost]
        public ActionResult<EventReadDTO> CreateEvent(EventCreateDTO eventCreateDto)
        {
            Event eventModel = _mapper.Map<Event>(eventCreateDto);
            _repository.Events.CreateEvent(eventModel);
            _repository.Save();
            EventReadDTO eventReadDto = _mapper.Map<EventReadDTO>(eventModel);
            return CreatedAtRoute(nameof(GetEventById), new { id = eventReadDto.EventId }, eventReadDto);
        }

        // DELETE api/event/{id}
        [HttpDelete]
        public ActionResult DeleteEvent(int id)
        {
            var eventFromRepo = _repository.Events.GetById(id,true);

            if (eventFromRepo == null) return NotFound();

            _repository.Events.DeleteEvent(eventFromRepo);
            _repository.Save();
            return NoContent();

        }

        //PUT api/event/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEvent(int id, EventUpdateDTO eventUpdateDto)
        {
            var eventFromRepo = _repository.Events.GetById(id, true);

            if (eventFromRepo == null) return NotFound();

            _mapper.Map(eventUpdateDto, eventFromRepo);
            _repository.Events.UpdateEvent(eventFromRepo);
            _repository.Save();

            return NoContent();
        }
    }
}

