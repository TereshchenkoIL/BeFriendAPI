using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data
{
    public class ChatRepository:RepositoryBase<Chat>, IChatRepository
    {
        public ChatRepository(befrienddbContext context) 
            :base(context)
        {

        }

        public void CreateChat(Chat chat)
        {
            Create(chat);
        }

        public void DeleteChat(Chat chat)
        {
            Delete(chat);
        }

        public List<Chat> GetAll(bool tracked = false)
        {
            return FindAll(tracked).ToList();
        }

        public Chat GetChatById(int id, bool tracked = false)
        {
            return FindByCondition(x => x.ChatId == id, tracked).FirstOrDefault();
        }

        public void UpdateChate(Chat chat)
        {
            Update(chat);
        }
    }
}
