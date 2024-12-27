using System;
using System.Collections.Generic;

namespace KiracuFlyerAPI.Model;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserStatus> UserStatuses { get; set; } = new List<UserStatus>();
}
