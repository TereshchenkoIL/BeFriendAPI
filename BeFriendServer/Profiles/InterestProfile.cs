using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeFriendServer.DTOs.Interest;
using BeFriendServer.Models;

namespace BeFriendServer.Profiles
{
    public class InterestProfile : Profile
    {
        public InterestProfile()
        {
            CreateMap<Interest, InterestDTO>();
            CreateMap<InterestDTO, Interest>();
        }
    }
}
