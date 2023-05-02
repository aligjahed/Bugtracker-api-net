namespace Bugtracker_api_net.Contracts;

public record LoginWithEmailContract(
    string Email,
    string Password
    );