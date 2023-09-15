using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface INotificationRepository
    {
        void CreateNotification(Notification notification);
        Notification UpdateNotification(int notificationId, Notification updatedNotification);
        void DeleteNotification(int notificationId);
        List<Notification> GetNotificationsByUserId(int userId);
        Notification GetNotificationById(int notificationId);
        void MarkNotificationAsRead(Notification notification);
    }
}
