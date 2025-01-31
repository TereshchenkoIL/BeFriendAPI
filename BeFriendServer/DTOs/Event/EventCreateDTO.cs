﻿using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.DTOs.Event
{
    public class EventCreateDTO
    {
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int AgeMin { get; set; }
        public int? SeatsLimit { get; set; }
        public string Photo { get; set; }
        public string EventDate { get; set; }
        public List<Models.Interest> Interests { get; set; }
        public List<Organizer> Organizers { get; set; }

    }
}
