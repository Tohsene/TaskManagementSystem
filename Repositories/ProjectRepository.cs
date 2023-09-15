using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void DeleteProject(int projectId)
        {
            var projectToDelete = _context.Projects.Find(projectId);
            if (projectToDelete != null)
            {
                _context.Projects.Remove(projectToDelete);
                _context.SaveChanges();
            }
        }

        public List<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public Project GetProjectById(int projectId)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == projectId);
        }

        public void UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }
    }
}
