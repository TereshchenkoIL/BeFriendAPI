using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFriendServer.Data.Interfaces;

namespace BeFriendServer.Data
{
    interface IRepositoryManager
    {
        IChatRepository Chats { get; }
        IEventRepository Events { get; }
        IInterestRepository Interests { get; }
        IMessageRepository Messages { get; }
        INotificationRepository Notifications { get; }
        IPaymentRepository Payments { get; }
        IUserRepository Users { get; }
        void Save();
    }
}
