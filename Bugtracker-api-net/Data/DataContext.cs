using Bugtracker_api_net.Entities;
using Bugtracker_api_net.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bugtracker_api_net.Data;

public class DataContext : DbContext, IDbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        base.OnConfiguring(options);

        options.UseNpgsql(_configuration.GetConnectionString("POSTGRES"));
    }

    public DbSet<Company> BugTrackerCompany { get; set; }
    public DbSet<Manager> BugTrackerManager { get; set; }
    public DbSet<Employee> BugTrackerEmployees { get; set; }
    public DbSet<Project> BugTrackerProjects { get; set; }
    public DbSet<Issue> BugTrackerIssues { get; set; }
    public DbSet<Report> BugTrackerReports { get; set; }
    public DbSet<Review> BugTrackerReviews { get; set; }
    public DbSet<Notification> BugTrackerNotifications { get; set; }
}