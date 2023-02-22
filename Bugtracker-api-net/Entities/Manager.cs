using Bugtracker_api_net.Entities.Common;

namespace Bugtracker_api_net.Entities;

public class Manager : UserBase
{
    public virtual Company Company { get; set; } = new();
}