using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Issue : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueTo { get; set; }
    public virtual Company Company { get; set; } = new();
    public virtual Employee Employee { get; set; } = new();
    public virtual Project Project { get; set; } = new();
    public virtual Report Report { get; set; } = new();
}