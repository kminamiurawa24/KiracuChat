using System;
using System.Collections.Generic;

namespace KiracuFlyerAPI.Model;

public partial class UserIcon
{
    public int Id { get; set; }

    public int IconLevel { get; set; }

    public string BatchImageUrl { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
