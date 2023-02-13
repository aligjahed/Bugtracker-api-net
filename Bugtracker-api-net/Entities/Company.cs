using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual List<Manager> Manager { get; set; } = new List<Manager>();
    public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    public virtual List<Project> Projects { get; set; } = new List<Project>();
    public virtual List<Issue> Issues { get; set; } = new List<Issue>();
    public virtual List<Client> Clients { get; set; } = new List<Client>();
    public virtual List<IssueReport> IssueReports { get; set; } = new List<IssueReport>();
}