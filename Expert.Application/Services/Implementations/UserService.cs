using Expert.Application.InputModels;
using Expert.Application.OutPutModels;
using Expert.Application.Services.Interfaces;
using Expert.Domain.Entities;
using Expert.Infrastructure.Persistance;

namespace Expert.Application.Services.Implementations
{
    public class UserService(ExpertDbContext dbContext) : IUserService
    {
        public readonly ExpertDbContext _dbContext = dbContext;
        public int Create(CreateUserModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return user.Id;
        }

        public UserOutputModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);


            if (user == null) return null;

            return new UserOutputModel(user.FullName, user.Email);
        }
    }
}
