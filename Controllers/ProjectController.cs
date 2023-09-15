using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Dto;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // Create a new project
        [HttpPost("Create Project")]
        public IActionResult CreateProject([FromBody] ProjectDto projectDto)
        {
            try
            {
                var project = _projectService.CreateProject(projectDto);
                return CreatedAtAction(nameof(GetProjectById), new { projectId = project.Id }, project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Update an existing project by ID
        [HttpPut("Update Project")]
        public IActionResult UpdateProject(int projectId, [FromBody] ProjectDto projectDto)
        {
            try
            {
                var updatedProject = _projectService.UpdateProject(projectId, projectDto);
                return Ok(updatedProject);
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

        // Delete a project by ID
        [HttpDelete("Delete Project")]
        public IActionResult DeleteProject(int projectId)
        {
            try
            {
                _projectService.DeleteProject(projectId);
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

        // Get a project by ID
        [HttpGet("GetProjectById")]
        public IActionResult GetProjectById(int projectId)
        {
            try
            {
                var project = _projectService.GetProjectById(projectId);
                return Ok(project);
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

        // Get all projects
        [HttpGet("GetAllProjects")]
        public IActionResult GetAllProjects()
        {
            try
            {
                var projects = _projectService.GetAllProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
