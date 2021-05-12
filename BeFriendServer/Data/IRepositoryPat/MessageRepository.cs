using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(befrienddbContext context)
            :base(context)
        {

        }

        public void CreateMessage(Message message)
        {
            Create(message);
        }

        public void DeleteMessage(Message message)
        {
            Delete(message);
        }

        public List<Message> GetAll(bool tracked = false)
        {
            return FindAll(tracked).ToList();
        }

        public Message GetById(int id, bool tracked = false)
        {
            return FindByCondition(x => x.MessageId == id, tracked).FirstOrDefault();
        }

        public List<Message> GetChatsMessages(int chatId, bool tracked = false)
        {
            return FindByCondition(x => x.ChatId == chatId, tracked).ToList();
        }

        public void UpdateMessage(Message message)
        {
            Update(message);
        }
    }
}
