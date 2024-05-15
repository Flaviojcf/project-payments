namespace Expert.Domain.Services
{
    public interface IAuthService
    {
        string GenerateJwtToke(string email, string role);
    }
}
