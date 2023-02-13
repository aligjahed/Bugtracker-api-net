using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Client : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Report> Reports { get; set; } = new List<Report>();
}