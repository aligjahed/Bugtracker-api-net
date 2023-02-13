using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Report : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual Company Company { get; set; } = new Company();
    public virtual Project Project { get; set; } = new Project();
}