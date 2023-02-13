using System.ComponentModel.DataAnnotations;

namespace Bugtracker_api_net.Entities.Common;

public class UserBase : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public List<string> PreviousRoles { get; set; } = new List<string>();
    public bool IsEmailConfirmed { get; set; } = false;
    public bool IsLockout { get; set; } = false;
}