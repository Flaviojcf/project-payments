using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Expert.Infrastructure.Persistance.Repositories
{
    public class SkillsRepository(ExpertDbContext dbContext) : ISkillsRepository
    {
        private readonly ExpertDbContext _dbContext = dbContext;
        public async Task<List<Skill>> GetAllAsync()
        {
            return await _dbContext.Skills.ToListAsync();
        }
    }
}
