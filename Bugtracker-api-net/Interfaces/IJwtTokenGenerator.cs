namespace Bugtracker_api_net.Interfaces;

public interface IJwtTokenGenerator
{
    public string GenerateToken(Guid userId,string firstName, string lastName , string role);
}