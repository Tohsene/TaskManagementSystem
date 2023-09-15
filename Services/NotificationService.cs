using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public List<Notification> GetUserNotifications(int userId)
        {
            return _notificationRepository.GetNotificationsByUserId(userId);
        }

        public void MarkNotificationAsRead(int notificationId)
        {
            var notification = _notificationRepository.GetNotificationById(notificationId);

            if (notification == null)
            {
                throw new NotFoundException("Notification not found"); // Custom exception for not found
            }

            if (!notification.IsRead)
            {
                notification.IsRead = true;
                _notificationRepository.MarkNotificationAsRead(notification);
            }
        }
    }
}
