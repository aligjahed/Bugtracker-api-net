using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Project : BaseEntity
{
    public virtual Company Company { get; set; } 
    public virtual List<Issue> Issues { get; set; } 
    public virtual List<Review> Reviews { get; set; } 
    public virtual List<Report> Reports { get; set; } 
}