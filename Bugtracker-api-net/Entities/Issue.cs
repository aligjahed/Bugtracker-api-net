using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Issue : BaseEntity
{
    public virtual Company Company { get; set; } = new();
    public virtual Employee Employee { get; set; } = new();
    public virtual Report Report { get; set; } = new();
}