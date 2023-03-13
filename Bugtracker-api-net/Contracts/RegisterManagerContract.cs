namespace Bugtracker_api_net.Contracts;

public record RegisterManagerContract(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password,
    string CompanyName
);