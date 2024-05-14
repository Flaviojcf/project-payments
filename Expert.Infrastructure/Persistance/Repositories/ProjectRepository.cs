using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expert.Infrastructure.Persistance.Repositories
{
    public class ProjectRepository(ExpertDbContext dbContext) : IProjectRepository
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _dbContext.Projects
               .Include(p => p.Client)
               .Include(p => p.Freelancer)
               .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCommentAsync(ProjectComment comment)
        {
            var projectComment = new ProjectComment(comment.Content, comment.IdProject, comment.IdUser);

            await _dbContext.Comments.AddAsync(projectComment);

            await _dbContext.SaveChangesAsync();
        }
    }
}
