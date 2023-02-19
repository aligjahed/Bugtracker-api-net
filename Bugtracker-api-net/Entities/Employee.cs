using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Employee : UserBase
{
    public bool IsActivated { get; set; } = false;
    public virtual Company Company { get; set; } = new();
    public virtual List<Issue> Issues { get; set; } = new();
    public virtual List<Report> Reports { get; set; } = new();
}