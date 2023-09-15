using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Dto;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface IProjectService
    {
        Project CreateProject(ProjectDto projectDto);
        Project UpdateProject(int projectId, ProjectDto projectDto);
        void DeleteProject(int projectId);
        Project GetProjectById(int projectId);
        List<Project> GetAllProjects();
    }
}
