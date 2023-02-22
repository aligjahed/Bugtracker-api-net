using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual Manager Manager { get; set; } = new();
    public virtual List<Employee> Employees { get; set; } = new();
    public virtual List<Project> Projects { get; set; } = new();
    public virtual List<Issue> Issues { get; set; } = new();
    public virtual List<Report> Reports { get; set; } = new();
    public virtual List<Review> Reviews { get; set; } = new();
}