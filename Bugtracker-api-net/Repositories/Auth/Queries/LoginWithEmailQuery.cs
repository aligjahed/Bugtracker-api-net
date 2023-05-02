using System.Net;
using Bugtracker_api_net.Contracts;
using Bugtracker_api_net.Data;
using Bugtracker_api_net.Entities.Common;
using Bugtracker_api_net.Interfaces;
using Bugtracker_api_net.Middleware.Common;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bugtracker_api_net.Repositories.Auth.Queries;

public class LoginWithEmailQuery : IRequest<LoginResponse>
{
    public LoginWithEmailContract LoginWithEmailContract { get; set; }
}

public class LoginQueryHandler : IRequestHandler<LoginWithEmailQuery, LoginResponse>
{
    private IValidator<LoginWithEmailQuery> _validator;
    private DataContext _context;
    private PasswordHasher<UserBase> _passwordHasher;
    private IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(
        IValidator<LoginWithEmailQuery> validator,
        DataContext context,
        PasswordHasher<UserBase> passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _validator = validator;
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResponse> Handle(LoginWithEmailQuery request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request);

        if (!validator.IsValid)
        {
            throw new CostumeException(statusCode: HttpStatusCode.BadRequest,
                message: validator.Errors[0].ErrorMessage);
        }

        var contract = request.LoginWithEmailContract;

        if (string.IsNullOrEmpty(contract.Email))
            throw new CostumeException(statusCode: HttpStatusCode.BadRequest,
                message: "Email can't be empty");

        // TODO: Refactor this so the user is seperated from manager and employee
        UserBase user = await _context.BugTrackerManager.FirstOrDefaultAsync(x => x.Email == contract.Email);
        if (user is null) user = await _context.BugTrackerEmployees.FirstOrDefaultAsync(x => x.Email == contract.Email);
        if (user is null) throw new CostumeException(HttpStatusCode.NotFound, "User Does not exist");

        var verifyHashedPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, contract.Password);

        if (verifyHashedPassword == PasswordVerificationResult.Failed)
            throw new CostumeException(HttpStatusCode.BadRequest, "Wrong credentials");

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName, user.Role);
        return new LoginResponse(token);
    }
}