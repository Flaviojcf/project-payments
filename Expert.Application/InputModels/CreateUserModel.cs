namespace Expert.Application.InputModels
{
    public class CreateUserModel(string fullName, string email, DateTime birthDate)
    {
        public string FullName { get; set; } = fullName;
        public string Email { get; set; } = email;
        public DateTime BirthDate { get; set; } = birthDate;
    }
}
