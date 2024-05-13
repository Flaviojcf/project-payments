namespace Expert.Application.OutPutModels
{
    public class UserOutputModel(string fullName, string email)
    {
        public string FullName { get; set; } = fullName;
        public string Email { get; set; } = email;
    }
}
