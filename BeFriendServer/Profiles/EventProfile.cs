using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeFriendServer.DTOs.Event;
using BeFriendServer.Models;

namespace BeFriendServer.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventCreateDTO, Event>();
            CreateMap<EventUpdateDTO, Event>();
            CreateMap<Event, EventUpdateDTO>();
            CreateMap<Event, EventReadDTO>().ForMember(dest => dest.Interests,
                opt => opt.MapFrom(src => src.InterestsEvents.Select(x=>x.Interest).ToList()
            ));
        }
    }
}
