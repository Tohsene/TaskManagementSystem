using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using TaskManagementSystem.Dto;
using TaskManagementSystem.Enum;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskService taskService, ITaskRepository taskRepository)
        {
            _taskService = taskService;
            _taskRepository = taskRepository;
        }

        [HttpPost("Create Task")]
        public ActionResult<Tasks> CreateTask(TaskDto taskDto)
        {
            var task = _taskService.CreateTask(taskDto);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        // Update an existing task by ID
        [HttpPut("Update Task")]
        public IActionResult UpdateTask(int taskId, [FromBody] TaskDto taskDto)
        {
            try
            {
                var updatedTask = _taskService.UpdateTask(taskId, taskDto);
                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Delete a task by ID
        [HttpDelete("Delete Task")]
        public IActionResult DeleteTask(int taskId)
        {
            try
            {
                _taskService.DeleteTask(taskId);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Get a task by ID
        [HttpGet("GetTaskById")]
        public IActionResult GetTaskById(int taskId)
        {
            try
            {
                var task = _taskService.GetTaskById(taskId);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // GET: api/tasks/status/{status}
        [HttpGet("GetTasksByStatus/{status}")]
        public IActionResult GetTasksByStatus(TaskStatus status)
        {
            var tasks = _taskRepository.GetTasksByStatus(status);
            return Ok(tasks);
        }

        // GET: api/tasks/priority/{priority}
        [HttpGet("GetTasksByPriority/{priority}")]
        public IActionResult GetTasksByPriority(TaskPriority priority)
        {
            var tasks = _taskRepository.GetTasksByPriority(priority);
            return Ok(tasks);
        }

        [HttpGet("GetTasksDueWithinTimeFrame")]
        public IActionResult GetTasksDueWithinTimeFrame([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            try
            {
                var tasks = _taskRepository.GetTasksDueWithinTimeFrame(startTime, endTime);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AssignTaskToProject")]
        public IActionResult AssignTaskToProject(int taskId, int projectId)
        {
            try
            {
                var task = _taskRepository.AssignTaskToProject(taskId, projectId);
                return Ok(task);
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

        // POST: api/tasks/remove-from-project
        [HttpPost("RemoveTaskFromProject")]
        public IActionResult RemoveTaskFromProject(int taskId)
        {
            try
            {
                var task = _taskRepository.RemoveTaskFromProject(taskId);
                return Ok(task);
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


    }
}
