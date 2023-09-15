using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TaskManagementSystem.Dto;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Tasks CreateTask(TaskDto taskDto)
        {
            var task = new Tasks
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                Priority = taskDto.Priority,
                Status = taskDto.Status,
                ProjectId = taskDto.ProjectId,
                CreatorId = taskDto.CreatorId,
                CreatedAt = DateTime.UtcNow
            };

            _taskRepository.CreateTask(task);
            return task;
        }

        public void DeleteTask(int taskId)
        {
            var existingTask = _taskRepository.GetTaskById(taskId);

            if (existingTask == null)
            {
                var responseModel = new ResponseModel
            {
                ResponseCode = HttpStatusCode.BadRequest,
                Message = "Task not found",
                Data = false
            };
                //throw responseModel; 
            }

            _taskRepository.DeleteTask(taskId);
        }

        public Tasks GetTaskById(int taskId)
        {
            var task = _taskRepository.GetTaskById(taskId);

            if (task == null)
            {
                throw new NotFoundException("Task not found");
            }

            return task;
        }

        public Tasks UpdateTask(int taskId, TaskDto taskDto)
        {
            var existingTask = _taskRepository.GetTaskById(taskId);

            if (existingTask == null)
            {
                throw new NotFoundException("Task not found"); // 
            }

            existingTask.Title = taskDto.Title;
            existingTask.Description = taskDto.Description;
            existingTask.DueDate = taskDto.DueDate;
            existingTask.Priority = taskDto.Priority;
            existingTask.Status = taskDto.Status;
            existingTask.ProjectId = taskDto.ProjectId;
            existingTask.CreatorId = taskDto.CreatorId;

            _taskRepository.UpdateTask(existingTask);
            return existingTask;
        }
    }
}
