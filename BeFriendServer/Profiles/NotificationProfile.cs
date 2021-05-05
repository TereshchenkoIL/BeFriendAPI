using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeFriendServer.DTOs.Notification;
using BeFriendServer.Models;

namespace BeFriendServer.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationReadDTO>();
        }
    }
}
