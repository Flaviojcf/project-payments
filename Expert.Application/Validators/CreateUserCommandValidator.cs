using Expert.Application.Commands.CreateUserCommand;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Expert.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage("E-mail não válido");

            RuleFor(u => u.Password).Must(ValidPassword)
                                    .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maíscula, uma letra minúscula e um caracter especial!");

            RuleFor(u => u.FullName).NotEmpty()
                                    .NotNull()
                                    .WithMessage("Nome é obrigatório!");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
