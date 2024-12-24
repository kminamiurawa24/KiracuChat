using System;
using System.Collections.Generic;

namespace KiracuFlyerAPI.Model;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int CreatedUserId { get; set; }

    public DateTime? CreatedDay { get; set; }

    public DateTime? ModifiedDay { get; set; }

    public virtual ICollection<Channel> Channels { get; set; } = new List<Channel>();

    public virtual User CreatedUser { get; set; } = null!;

    public virtual ICollection<GroupAdmin> GroupAdmins { get; set; } = new List<GroupAdmin>();
}
