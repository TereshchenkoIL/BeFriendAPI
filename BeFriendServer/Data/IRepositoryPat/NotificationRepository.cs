using BeFriendServer.Data.Interfaces;
using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(befrienddbContext context)
            :base(context)
        {

        }

        public void CreateNotification(Notification notification)
        {
            Create(notification);
        }

        public void DeleteNotification(Notification notification)
        {
            Delete(notification);
        }

        public List<Notification> GetAll(bool tracked = false)
        {
            return FindAll(tracked).ToList();
        }

        public Notification GetById(int id, bool tracked = false)
        {
            return FindByCondition(x => x.NotificationsId == id, tracked).FirstOrDefault();
        }

        public void UpdateNotification(Notification notification)
        {
            Update(notification);
        }
    }
}
