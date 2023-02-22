using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Review : BaseEntity
{
    public string ClientFirstName { get; set; } = string.Empty;
    public string ClientLastName { get; set; } = string.Empty;
    public string ClientEmail { get; set; } = string.Empty;
    public int Rate { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public virtual Company Company { get; set; } = new();
    public virtual Project Project { get; set; } = new();
}