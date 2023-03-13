using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Issue : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueTo { get; set; }
    public virtual Company Company { get; set; } 
    public virtual Employee Employee { get; set; } 
    public virtual Project Project { get; set; } 
    public virtual Report Report { get; set; } 
}