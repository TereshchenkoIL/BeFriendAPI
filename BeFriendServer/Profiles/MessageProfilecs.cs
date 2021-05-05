using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeFriendServer.DTOs.Message;
using BeFriendServer.Models;

namespace BeFriendServer.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageCreateDTO, Message>();
            CreateMap<Message, MessageReadDTO>();
        }
    }
}
