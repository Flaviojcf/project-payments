using Expert.Application.OutPutModels;
using Expert.Domain.Repositories;
using MediatR;

namespace Expert.Application.Queries.GetUser
{
    public class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, UserOutputModel>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserOutputModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return null;
            }

            return new UserOutputModel(user.FullName, user.Email);
        }
    }
}
