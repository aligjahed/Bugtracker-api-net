using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual Manager Manager { get; set; }
    public virtual List<Employee> Employees { get; set; } 
    public virtual List<Project> Projects { get; set; } 
    public virtual List<Issue> Issues { get; set; } 
    public virtual List<Report> Reports { get; set; } 
    public virtual List<Review> Reviews { get; set; } 
}