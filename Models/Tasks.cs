using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public int ProjectId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Project Project { get; set; }
        public User Creator { get; set; }
        public int AssigneeId { get; set; }
    }
}
