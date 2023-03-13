using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bugtracker_api_net.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Bugtracker_api_net.Services;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, string lastName , string role)
    {
        var signinCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("some-super-secret-key")),
            SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, firstName),
            new Claim(ClaimTypes.Surname, lastName),
            new Claim(ClaimTypes.Role, role),
        };

        var securityToken = new JwtSecurityToken(
            issuer: "BugTracker",
            audience: "BugTracker",
            claims: claims,
            signingCredentials: signinCredentials,
            expires: DateTime.UtcNow.AddMinutes(60));

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}