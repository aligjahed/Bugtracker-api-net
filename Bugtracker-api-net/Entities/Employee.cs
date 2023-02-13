using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Employee : UserBase
{
    public virtual Company Company { get; set; } = new Company();
    public virtual List<Issue> Issues { get; set; } = new List<Issue>();
    public virtual List<IssueReport> IssueReports { get; set; } = new List<IssueReport>();
}