﻿using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(befrienddbContext context)
            :base(context)
        {

        }
    }
}
