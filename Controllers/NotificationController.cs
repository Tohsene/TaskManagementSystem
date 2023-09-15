using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationService notificationService, INotificationRepository notificationRepository)
        {
            _notificationService = notificationService;
            _notificationRepository = notificationRepository;
        }

        // POST: api/notifications
        [HttpPost("Create Notification")]
        public IActionResult CreateNotification([FromBody] Notification notification)
        {
            try
            {
                _notificationRepository.CreateNotification(notification);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update Notification")]
        public IActionResult UpdateNotification(int notificationId, [FromBody] Notification updatedNotification)
        {
            try
            {
                var notification = _notificationRepository.UpdateNotification(notificationId, updatedNotification);
                return Ok(notification);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete Notification by ID
        [HttpDelete("Delete Notification")]
        public IActionResult DeleteNotification(int notificationId)
        {
            try
            {
                _notificationRepository.DeleteNotification(notificationId);
                return NoContent(); // 204 No Content
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Get notifications for a specific user
        [HttpGet("GetUserNotifications")]
        public IActionResult GetUserNotifications(int userId)
        {
            try
            {
                var notifications = _notificationService.GetUserNotifications(userId);
                return Ok(notifications);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Mark a notification as read
        [HttpPut("MarkNotificationAsRead")]
        public IActionResult MarkNotificationAsRead(int notificationId)
        {
            try
            {
                _notificationService.MarkNotificationAsRead(notificationId);
                return NoContent(); // 204 No Content
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
