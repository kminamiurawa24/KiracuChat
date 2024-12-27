using System;
using System.Collections.Generic;

namespace KiracuFlyerAPI.Model;

public partial class UserProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? ProfileImageUrl { get; set; }

    public string? Bio { get; set; }

    public virtual User User { get; set; } = null!;
}
