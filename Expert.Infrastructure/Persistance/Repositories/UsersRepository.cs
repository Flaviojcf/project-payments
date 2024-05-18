using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> GetByIdAsync(int id)
        {
            var userDb = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            return userDb;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }
    }
}
