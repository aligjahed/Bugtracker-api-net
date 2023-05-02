using FluentValidation;

namespace Bugtracker_api_net.Repositories.Auth.Queries;

public class LoginQueryValidator : AbstractValidator<LoginWithEmailQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.LoginWithEmailContract.Email)
            .EmailAddress()
            .NotEmpty()
            .WithMessage("Please use a valid email.");

        RuleFor(x => x.LoginWithEmailContract.Password)
            .NotEmpty()
            .WithMessage("Please provide a password");

    }
}