using Expert.Application.OutPutModels;
using Expert.Application.Services.Interfaces;
using Expert.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Expert.Application.Services.Implementations
{
    public class ProjectService(ExpertDbContext dbContext) : IProjectService
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public List<ProjectOutputModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsOutPut = projects.Select(p => new ProjectOutputModel(p.Id, p.Title, p.CreatedAt)).ToList();

            return projectsOutPut;
        }

        public ProjectDetailsOutputModel GetById(int id)
        {
            var project = _dbContext.Projects.Include(p => p.Client)
                                             .Include(p => p.Freelancer)
                                             .SingleOrDefault(p => p.Id == id);


            if (project == null) return null;

            var projectDetailsOutputModel = new ProjectDetailsOutputModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsOutputModel;
        }
    }
}
