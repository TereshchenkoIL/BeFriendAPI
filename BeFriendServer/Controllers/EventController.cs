using AutoMapper;
using BeFriendServer.Data;
using BeFriendServer.DTOs.Event;
using BeFriendServer.DTOs.Interest;
using BeFriendServer.DTOs.User;
using BeFriendServer.Models;
using BeFriendServer.SearchEngine;
using BeFriendServer.SearchEngine.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IEventMatcher _matcher;
        private readonly IWebHostEnvironment _appEnvironment;

        public EventController(IRepositoryManager manager, IMapper mapper, IEventMatcher matcher, IWebHostEnvironment appEnvironment)
        {
            _repository = manager;
            _mapper = mapper;
            _matcher = matcher;
            _appEnvironment = appEnvironment;
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

        // GET api/event/all
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

        // GET api/event/recommendation/{num}
        [HttpGet("recommendation/{num}")]
        public IActionResult GetRecommendation(string num)
        {
            User user = _repository.Users.GetByNumber(num);
            if (user == null) return NotFound();

            var results = _matcher.getRecommendation(user);
            return Ok(results);
        }

        // Post api/event/search/{num}
        [HttpPost("search/{num}")]
        public IActionResult GetPotentials(string num, [FromBody] EventSearchOptions options)
        {
            User user = _repository.Users.GetByNumber(num);
            if (user == null) return NotFound();

            var results = _matcher.Match(options, user);
            return Ok(results);
        }
        

        // GET api/event/byName/{name}
        [HttpGet("byName/{name}")]
        public IActionResult GetByNames(string name)
        {
            var results = _repository.Events.GetAll().Where(x => x.Name.ToLower().Contains(name.ToLower()));
            if (results == null) return NotFound();

            return Ok(_mapper.Map<List<EventReadDTO>>(results));
        }


        // POST api/event/photo/{id}
        [HttpPost("photo/{num}")]
        public async Task<IActionResult> SetPhoto(int id)
        {
            Event eventModel = _repository.Events.GetById(id,true);

            if (eventModel == null) return NotFound();
            string oldFile = Path.Combine(_appEnvironment.ContentRootPath, _appEnvironment.WebRootPath, "images/" + eventModel.Photo);

            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }

            var file = Request.Form.Files[0];
            string fName =eventModel.Name + "_" + Guid.NewGuid() + Path.GetExtension(file.FileName);
            eventModel.Photo = fName;
            string path = Path.Combine(_appEnvironment.ContentRootPath, _appEnvironment.WebRootPath, "images/" + fName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _repository.Save();
            return NoContent();
        }

        // POST api/event
        [HttpPost]
        public ActionResult<EventReadDTO> CreateEvent(EventCreateDTO eventCreateDto)
        {
            Event eventModel = _mapper.Map<Event>(eventCreateDto);
            _repository.Events.CreateEvent(eventModel);
            List<InterestsEvent> interests = new List<InterestsEvent>();
            _repository.Save();

            foreach (var interest in eventCreateDto.Interests)
            {
                interests.Add(new InterestsEvent() { EventId = eventModel.EventId, InterestId = interest.InterestId});
            }
            eventModel.InterestsEvents = interests;
            eventModel.Organizers = new List<Organizer>();
            foreach (var org in eventCreateDto.Organizers)
            {
                eventModel.Organizers.Add(new Organizer
                {
                    EventId = eventModel.EventId,
                    TelephoneNumber = org.TelephoneNumber
                });
            }
            _repository.Save();
            

            EventReadDTO eventReadDto = _mapper.Map<EventReadDTO>(eventModel);
            return CreatedAtRoute(nameof(GetEventById), new { id = eventReadDto.EventId }, eventReadDto);
        }


        // POST api/event/addInterests/{id}
        [HttpPost("addInterests/{id}")]
        public IActionResult AddInterests(int id, [FromBody] List<Interest> interests)
        {
            Event eventModel = _repository.Events.GetById(id, true);
            if (eventModel == null) return NotFound();

            _repository.Events.AddInterests(eventModel, interests);
            _repository.Save();
            return NoContent();
        }

        // POST api/event/addInterests/{id}
        [HttpPost("Interests/{id}")]
        public IActionResult AddInterest(int id, [FromBody] InterestDTO interest)
        {
            Event eventModel = _repository.Events.GetById(id, true);
            if (eventModel == null) return NotFound();
             Interest newInterest = _mapper.Map<Interest>(interest);
            _repository.Events.AddInterest(eventModel, newInterest);
            _repository.Save();
            return NoContent();
        }

        // POST api/event/Orginizers/{id}

        [HttpPost("Orginizers/{id}")]
        public IActionResult AddOrginizer(int id, [FromBody] string User_Num)
        {
            Event eventModel = _repository.Events.GetById(id, true);
            if (eventModel == null) return NotFound();

            User user = _repository.Users.GetByNumber(User_Num, true);

            if (user == null) return NotFound();
            if(eventModel.Organizers == null)
            {
                eventModel.Organizers = new List<Organizer>();
            }

            eventModel.Organizers.Add(new Organizer { 
            EventId = id,
            TelephoneNumber = User_Num});
            _repository.Save();

            return NoContent();
        }

        // DELETE api/event/Orginizers/{id}
        [HttpDelete("Organizers/{id}")]
        public IActionResult RemoveOrginizer(int id, [FromBody] string User_Num)
        {
            Event eventModel = _repository.Events.GetById(id, true);
            if (eventModel == null) return NotFound();

            User user = _repository.Users.GetByNumber(User_Num, true);

            if (user == null) return NotFound();

           Organizer orginizer = eventModel.Organizers.Where(x => x.TelephoneNumber == User_Num).FirstOrDefault();

            if (orginizer == null) return NotFound();

            eventModel.Organizers.Remove(orginizer);
            _repository.Save();

            return NoContent();
        }


        // DELETE api/event/Interests/{id}
        [HttpDelete("Interests/{id}")]
        public IActionResult RemoveInterest(int id, [FromBody] InterestDTO interestDto)
        {
            Event eventModel = _repository.Events.GetById(id, true);
            if (eventModel == null) return NotFound();

            Interest interest = _mapper.Map<Interest>(interestDto);
            InterestsEvent interestForRemove = eventModel.InterestsEvents.Where(x => x.InterestId == interest.InterestId).FirstOrDefault();
            if (interestForRemove == null) return NotFound();

            eventModel.InterestsEvents.Remove(interestForRemove);
            _repository.Save();
            return NoContent();
        }


        // DELETE api/event/{id}
        [HttpDelete("{id}")]
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

