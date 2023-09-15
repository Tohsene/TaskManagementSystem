using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }
        public Notification UpdateNotification(int notificationId, Notification updatedNotification)
        {
            var existingNotification = _context.Notifications.Find(notificationId);

            if (existingNotification == null)
            {
                throw new NotFoundException("Notification not found");
            }

            // Update notification properties
            existingNotification.Type = updatedNotification.Type;
            existingNotification.Message = updatedNotification.Message;

            _context.SaveChanges();

            return existingNotification;
        }

        // Delete Notification by ID
        public void DeleteNotification(int notificationId)
        {
            var notificationToDelete = _context.Notifications.Find(notificationId);

            if (notificationToDelete == null)
            {
                throw new NotFoundException("Notification not found");
            }

            _context.Notifications.Remove(notificationToDelete);
            _context.SaveChanges();
        }

        public Notification GetNotificationById(int notificationId)
        {
            return _context.Notifications.FirstOrDefault(n => n.Id == notificationId);
        }

        public List<Notification> GetNotificationsByUserId(int userId)
        {
            return _context.Notifications
            .Where(n => n.UserId == userId)
            .ToList();
        }

        public void MarkNotificationAsRead(Notification notification)
        {
            _context.Notifications.Update(notification);
            _context.SaveChanges();
        }
    }
}
