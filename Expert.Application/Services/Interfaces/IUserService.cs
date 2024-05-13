using Expert.Application.InputModels;

namespace Expert.Application.Services.Interfaces
{
    public interface IUserService
    {
        int Create(CreateUserModel inputModel);
    }
}
