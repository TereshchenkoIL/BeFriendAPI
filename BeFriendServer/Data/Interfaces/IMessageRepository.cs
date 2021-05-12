using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.Interfaces
{
    public interface IMessageRepository
    {
        Message GetById(int id, bool tracked = false);
        List<Message> GetAll(bool tracked = false);
        void CreateMessage(Message message);
        void DeleteMessage(Message message);
        void UpdateMessage(Message message);
        List<Message> GetChatsMessages(int chatId, bool tracked = false);
    }
}
