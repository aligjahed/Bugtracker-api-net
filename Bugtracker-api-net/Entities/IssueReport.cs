using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class IssueReport : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual Employee Employee { get; set; } = new Employee();
    public virtual Manager Manager { get; set; } = new Manager();
    public virtual Project Project { get; set; } = new Project();
    public virtual Issue Issue { get; set; } = new Issue();
}