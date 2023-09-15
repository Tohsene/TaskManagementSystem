using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Helpers
{
    public class NotificationChecker : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceProvider _services;

        public NotificationChecker(IServiceProvider services)
        {
            _services = services;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckNotifications, null, TimeSpan.Zero, TimeSpan.FromMinutes(30)); // Check every 30 minutes
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        private void CheckNotifications(object state)
        {
            using (var scope = _services.CreateScope())
            {
                var notificationRepository = scope.ServiceProvider.GetRequiredService<INotificationRepository>();
                var taskRepository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();

                var currentTime = DateTime.UtcNow;
                var dueDateThreshold = currentTime.AddHours(48);
                var tasksDueWithin48Hours = taskRepository.GetTasksDueWithinTimeFrame(currentTime, dueDateThreshold);

                foreach (var task in tasksDueWithin48Hours)
                {
                    var notification = new Notification
                    {
                        Type = "due date reminder",
                        Message = $"Task '{task.Title}' is due within 48 hours.",
                        UserId = task.AssigneeId, // Assignee user ID
                        Timestamp = DateTime.UtcNow
                    };

                    notificationRepository.CreateNotification(notification);
                }
            }
        }
    }
}
