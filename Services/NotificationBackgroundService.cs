using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public class NotificationBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _services;

        public NotificationBackgroundService(IServiceProvider services)
        {
            _services = services;
        }
        protected override async  Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var notificationRepository = scope.ServiceProvider.GetRequiredService<INotificationRepository>();
                    var taskRepository = scope.ServiceProvider.GetRequiredService<ITaskRepository>();
                   
                    var currentTime = DateTime.UtcNow;
                    var dueDateThreshold = currentTime.AddHours(48);

                    
                    var tasksWithDueDates = taskRepository.GetTasksDueWithinTimeFrame(currentTime, dueDateThreshold);

                    foreach (var task in tasksWithDueDates)
                    {
                        var notification = new Notification
                        {
                            Type = "due date reminder",
                            Message = $"Task '{task.Title}' is due on {task.DueDate.ToLocalTime()}",
                            UserId = task.AssigneeId, 
                            Timestamp = DateTime.UtcNow
                        };

                        notificationRepository.CreateNotification(notification);
                    }

                    await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken); 
                }
            }
        }
    }
}
