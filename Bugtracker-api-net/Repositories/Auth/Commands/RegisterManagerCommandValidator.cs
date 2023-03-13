using FluentValidation;

namespace Bugtracker_api_net.Repositories.Auth.Commands;

public class RegisterManagerCommandValidator : AbstractValidator<RegisterManagerCommand>
{
    public RegisterManagerCommandValidator()
    {
        RuleFor(v => v.Contract.FirstName)
            .NotEmpty()
            .Length(3, 10);

        RuleFor(v => v.Contract.LastName)
            .NotEmpty()
            .Length(3, 10);

        RuleFor(v => v.Contract.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(v => v.Contract.UserName)
            .NotEmpty()
            .Length(5, 32);

        RuleFor(v => v.Contract.Password)
            .NotEmpty()
            .Length(8, 32).WithMessage("The password must be at least 8 characters.")
            .Must(x => x.Any(char.IsUpper)).WithMessage("Password must contain capital letters")
            .Must(x => x.Any(char.IsNumber)).WithMessage("Password must contain numbers")
            .Must(x => x.Any(char.IsLower)).WithMessage("Password should contain lower letters");

        RuleFor(v => v.Contract.CompanyName)
            .NotEmpty()
            .Length(5, 32);

    }
}