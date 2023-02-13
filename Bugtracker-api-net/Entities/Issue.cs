using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Issue : BaseEntity
{
    public virtual Company Company { get; set; } = new Company();
    public virtual Manager Creator { get; set; } = new Manager();
    public virtual Employee Employee { get; set; } = new Employee();
    public virtual Report? Report { get; set; } = new Report();
    public virtual List<IssueReport> IssueReports { get; set; } = new List<IssueReport>();
    public virtual List<Employee> Companions { get; set; } = new List<Employee>();
}