using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Reviews : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Rate { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public Project Project { get; set; } = new();
}