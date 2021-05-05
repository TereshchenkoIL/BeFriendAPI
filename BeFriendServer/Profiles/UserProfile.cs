using AutoMapper;
using BeFriendServer.DTOs.User;
using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>().ForMember(dest => dest.Interests,
                opt=> opt.MapFrom(src=>src.InterestsUsers.Select(x => x.Interest).ToList()
            ));

            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserUpdateDTO>();
        }
    }
}
