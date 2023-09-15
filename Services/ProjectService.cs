using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Dto;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories;

namespace TaskManagementSystem.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public Project CreateProject(ProjectDto projectDto)
        {
            var project = new Project
            {
                Name = projectDto.Name,
                Description = projectDto.Description
            };

            _projectRepository.CreateProject(project);
            return project;
        }

        public void DeleteProject(int projectId)
        {
            var existingProject = _projectRepository.GetProjectById(projectId);

            if (existingProject == null)
            {
                throw new NotFoundException("Project not found"); // Custom exception for not found
            }

            _projectRepository.DeleteProject(projectId);
        }

        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAllProjects(); 
        }

        public Project GetProjectById(int projectId)
        {
            var project = _projectRepository.GetProjectById(projectId);

            if (project == null)
            {
                throw new NotFoundException("Project not found"); // Custom exception for not found
            }

            return project;
        }

        public Project UpdateProject(int projectId, ProjectDto projectDto)
        {
            var existingProject = _projectRepository.GetProjectById(projectId);

            if (existingProject == null)
            {
                throw new NotFoundException("Project not found"); // Custom exception for not found
            }

            // Update the existing project with the new data from the DTO
            existingProject.Name = projectDto.Name;
            existingProject.Description = projectDto.Description;

            _projectRepository.UpdateProject(existingProject);
            return existingProject;
        }
    }
}
