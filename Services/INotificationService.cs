using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface INotificationService
    {
        List<Notification> GetUserNotifications(int userId);
        void MarkNotificationAsRead(int notificationId);
    }
}
