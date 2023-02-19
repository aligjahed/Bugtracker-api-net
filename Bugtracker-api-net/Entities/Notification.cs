using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Notification : BaseEntity
{
    public string NotificationMessage { get; set; } = string.Empty;
}