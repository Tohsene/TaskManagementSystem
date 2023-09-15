using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using TaskManagementSystem.Data;
using TaskManagementSystem.Enum;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateTask(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var taskToDelete = _context.Tasks.Find(id);
            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                _context.SaveChanges();
            }
        }

        public Tasks GetTaskById(int id)
        {
            return _context.Tasks
            .Include(t => t.Project)
            .Include(t => t.Creator)
            .FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTask(Tasks task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
        public List<Tasks> GetTasksByStatus(TaskStatus status)
        {
            return _context.Tasks.Where(task => task.Status == status.ToString()).ToList();
        }

        public List<Tasks> GetTasksByPriority(TaskPriority priority)
        {
            return _context.Tasks.Where(task => task.Priority == priority.ToString()).ToList();
        }
        public List<Tasks> GetTasksDueWithinTimeFrame(DateTime startTime, DateTime endTime)
        {
            return _context.Tasks
                .Where(task => task.DueDate >= startTime && task.DueDate <= endTime)
                .ToList();
        }
        public Tasks AssignTaskToProject(int taskId, int projectId)
        {
            var task = _context.Tasks.Find(taskId);
            var project = _context.Projects.Find(projectId);

            if (task == null || project == null)
            {
                throw new NotFoundException("Task or project not found.");
            }

            task.Project = project;
            _context.SaveChanges();

            return task;
        }

        public Tasks RemoveTaskFromProject(int taskId)
        {
            var task = _context.Tasks.Find(taskId);

            if (task == null)
            {
                throw new NotFoundException("Task not found.");
            }

            task.Project = null;
            _context.SaveChanges();

            return task;
        }
    }
}
