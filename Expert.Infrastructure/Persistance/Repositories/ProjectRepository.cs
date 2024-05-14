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
    }
}
