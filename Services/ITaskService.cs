using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Dto;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface ITaskService
    {
        Tasks CreateTask(TaskDto taskDto);
        Tasks UpdateTask(int taskId, TaskDto taskDto);
        void DeleteTask(int taskId);
        Tasks GetTaskById(int taskId);
    }
}
