using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public interface IProjectRepository
    {
        Project GetProjectById(int projectId);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
        List<Project> GetAllProjects();
    }
}
