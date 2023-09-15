using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagementSystem.Enum;
//using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface ITaskRepository
    {
        Tasks GetTaskById(int id);
        void CreateTask(Tasks task);
        void UpdateTask(Tasks task);
        void DeleteTask(int id);
        List<Tasks> GetTasksByStatus(TaskStatus status);
        List<Tasks> GetTasksByPriority(TaskPriority priority);
        List<Tasks> GetTasksDueWithinTimeFrame(DateTime startTime, DateTime endTime);
        Tasks AssignTaskToProject(int taskId, int projectId);
        Tasks RemoveTaskFromProject(int taskId);
    }
}
