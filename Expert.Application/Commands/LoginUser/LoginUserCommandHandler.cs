using Expert.Application.OutPutModels;
using Expert.Domain.Repositories;
using Expert.Domain.Services;
using MediatR;

namespace Expert.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository) : IRequestHandler<LoginUserCommand, LoginUserOutputModel>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IAuthService _authService = authService;
        public async Task<LoginUserOutputModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(user?.Email, user.Role);

            var loginUserOutputModel = new LoginUserOutputModel(user.Email, token);

            return loginUserOutputModel;
        }
    }
}
