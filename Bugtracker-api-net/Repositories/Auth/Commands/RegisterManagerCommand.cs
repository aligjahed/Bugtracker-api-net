using System.Diagnostics.Contracts;
using System.Net;
using Bugtracker_api_net.Contracts;
using Bugtracker_api_net.Data;
using Bugtracker_api_net.Entities;
using Bugtracker_api_net.Entities.Common;
using Bugtracker_api_net.Interfaces;
using Bugtracker_api_net.Middleware.Common;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bugtracker_api_net.Repositories.Auth.Commands;

public class RegisterManagerCommand : IRequest<RegisterManagerResponse>
{
    public RegisterManagerContract Contract { get; set; }
}

public class RegisterManagerCommandHandler : IRequestHandler<RegisterManagerCommand, RegisterManagerResponse>
{
    private readonly DataContext _context;
    private readonly IValidator<RegisterManagerCommand> _validator;
    private readonly PasswordHasher<UserBase> _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;


    public RegisterManagerCommandHandler(
        IValidator<RegisterManagerCommand> validator,
        DataContext context,
        PasswordHasher<UserBase> passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _validator = validator;
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<RegisterManagerResponse> Handle(RegisterManagerCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _validator.ValidateAsync(request);

        if (!result.IsValid)
        {
            throw new CostumeException(statusCode: HttpStatusCode.BadRequest, message: result.Errors[0].ToString());
        }

        var contract = request.Contract;

        var managerExist = await _context.BugTrackerManager
            .FirstOrDefaultAsync(x => x.Email == contract.Email);

        if (managerExist is not null)
        {
            throw new CostumeException(HttpStatusCode.Conflict,
                "Manager with the same email already exist. Please login.");
        }

        var company = new Company()
        {
            Name = contract.CompanyName
        };

        var manager = new Manager()
        {
            FirstName = contract.FirstName,
            LastName = contract.LastName,
            Email = contract.Email,
            Username = contract.UserName,
            Role = "Manager",
            Company = company,
            CompanyID = company.Id
        };

        company.Manager = manager;

        var passwordHash = _passwordHasher.HashPassword(manager, contract.Password);
        manager.PasswordHash = passwordHash;

        await _context.BugTrackerManager.AddAsync(manager);
        await _context.SaveChangesAsync();

        var token = _jwtTokenGenerator.GenerateToken(manager.Id, manager.FirstName, manager.LastName, manager.Role);

        return new RegisterManagerResponse(Token: token);
    }
}