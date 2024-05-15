using Expert.Application.OutPutModels;
using MediatR;

namespace Expert.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserOutputModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
