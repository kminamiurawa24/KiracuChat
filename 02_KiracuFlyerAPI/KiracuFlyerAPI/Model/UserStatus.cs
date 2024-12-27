using System;
using System.Collections.Generic;

namespace KiracuFlyerAPI.Model;

public partial class UserStatus
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int StatusId { get; set; }

    public string? CustomMessage { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
