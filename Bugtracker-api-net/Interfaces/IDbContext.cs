using Bugtracker_api_net.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bugtracker_api_net.Interfaces;

public interface IDbContext 
{
    public DbSet<Company> BugTrackerCompany { get; set; }
    public DbSet<Manager> BugTrackerManager { get; set; }
    public DbSet<Employee> BugTrackerEmployees { get; set; }
    public DbSet<Project> BugTrackerProjects { get; set; }
    public DbSet<Issue> BugTrackerIssues { get; set; }
    public DbSet<Report> BugTrackerReports { get; set; }
    public DbSet<Review> BugTrackerReviews { get; set; }
    public DbSet<Notification> BugTrackerNotifications { get; set; }

}