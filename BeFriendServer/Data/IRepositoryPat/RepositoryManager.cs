using BeFriendServer.Data.Interfaces;
using BeFriendServer.Data.IRepositoryPat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private befrienddbContext _dbcontext;
        private IEventRepository _eventRepository;
        private IChatRepository _chatRepository;
        private IInterestRepository _interestRepository;
        private IMessageRepository _messageRepository;
        private INotificationRepository _notificationRepository;
        private IPaymentRepository _paymentRepository;
        private IUserRepository _userRepository;
        public IFriendsRepository _friendsRepository;
        public ISocialsRepository _socialsRepository;
        public RepositoryManager(befrienddbContext context)
        {
            _dbcontext = context;
        }
        public IFriendsRepository Friends
        {
            get
            {

                if (_friendsRepository == null)
                    _friendsRepository = new FriendsRepository(_dbcontext);
                return _friendsRepository;
            }
        }
        public IChatRepository Chats
        {
            get {

                if (_chatRepository == null)
                    _chatRepository = new ChatRepository(_dbcontext);
                return _chatRepository;
            }
        }

        public IEventRepository Events
        {
            get
            {

                if (_eventRepository == null)
                    _eventRepository = new EventRepository(_dbcontext);
                return _eventRepository;
            }
        }

        public IInterestRepository Interests
        {
            get
            {

                if (_interestRepository == null)
                    _interestRepository = new InterestRepository(_dbcontext);
                return _interestRepository;
            }
        }

        public IMessageRepository Messages
        {
            get
            {

                if (_messageRepository == null)
                    _messageRepository = new MessageRepository(_dbcontext);
                return _messageRepository;
            }
        }
        public INotificationRepository Notifications
        {
            get
            {

                if (_notificationRepository == null)
                    _notificationRepository = new NotificationRepository(_dbcontext);
                return _notificationRepository;
            }
        }
        public IPaymentRepository Payments
        {
            get
            {

                if (_paymentRepository == null)
                    _paymentRepository = new PaymentRepository(_dbcontext);
                return _paymentRepository;
            }
        }
        public IUserRepository Users
        {
            get
            {

                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbcontext);
                return _userRepository;
            }
        }

        public ISocialsRepository Socials
        {
            get
            {

                if (_socialsRepository == null)
                    _socialsRepository = new SocialsRepository(_dbcontext);
                return _socialsRepository;
            }
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}
