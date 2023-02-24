using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Report : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual Company Company { get; set; } = new();
    public virtual Employee Employee { get; set; } = new();
    public virtual Project Project { get; set; } = new();
    public Guid IssueID { get; set; }
    public virtual Issue Issue { get; set; } = new();
}