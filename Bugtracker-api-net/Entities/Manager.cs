using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Manager : UserBase
{
    public virtual Company Company { get; set; } = new Company();
    public virtual List<Project> Projects { get; set; } = new List<Project>();
    public virtual List<Issue> CreatedIssues { get; set; } = new List<Issue>();
}