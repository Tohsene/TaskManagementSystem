using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Type { get; set; } // e.g., "due date reminder", "status update"
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

        // Foreign key to associate with a user
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
