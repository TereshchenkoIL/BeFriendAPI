using BeFriendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendServer.Data.Interfaces
{
    public interface INotificationRepository
    {
        Notification GetById(int id, bool tracked = false);
        List<Notification> GetAll(bool tracked = false);

        void CreateNotification(Notification notification);
        void DeleteNotification(Notification notification);
        void UpdateNotification(Notification notification);
    }
}
