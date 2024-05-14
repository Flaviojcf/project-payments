using Expert.Application.OutPutModels;
using Expert.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Expert.Application.Queries.GetUser
{
    public class GetUserQueryHandler(ExpertDbContext dbContext) : IRequestHandler<GetUserQuery, UserOutputModel>
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public async Task<UserOutputModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user == null)
            {
                return null;
            }

            return new UserOutputModel(user.FullName, user.Email);
        }
    }
}
