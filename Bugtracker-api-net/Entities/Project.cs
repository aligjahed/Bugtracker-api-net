using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Project : BaseEntity
{
    public virtual Company Company { get; set; } = new Company();
    public virtual Manager Creator { get; set; } = new Manager();
    public virtual List<Manager> Managers { get; set; } = new List<Manager>();
    public virtual List<Issue> Issues { get; set; } = new List<Issue>();
    public virtual List<Employee> Employees { get; set; } = new List<Employee>();
}