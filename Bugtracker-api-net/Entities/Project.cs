using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Project : BaseEntity
{
    public virtual Company Company { get; set; } = new();
    public virtual List<Issue> Issues { get; set; } = new();
    public virtual List<Review> Reviews { get; set; } = new();
    public virtual List<Report> Reports { get; set; } = new();
}