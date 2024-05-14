using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using MediatR;

namespace Expert.Application.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Email, request.BirthDate);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
