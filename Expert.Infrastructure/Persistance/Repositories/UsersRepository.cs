using Expert.Domain.Entities;
using Expert.Domain.Repositories;

namespace Expert.Infrastructure.Persistance.Repositories
{
    public class UsersRepository(ExpertDbContext dbContext) : IUserRepository
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
