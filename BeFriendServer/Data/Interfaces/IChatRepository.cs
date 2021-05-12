using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.Interfaces
{
    public interface IChatRepository
    {
        Chat GetChatById(int id, bool tracked = false);
        List<Chat> GetAll(bool tracked = false);
        void CreateChat(Chat chat);
        void DeleteChat(Chat chat);
        void UpdateChate(Chat chat);
    }
}
