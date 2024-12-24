using System;
using System.Collections.Generic;

namespace KiracuFlyerAPI.Model;

public partial class GroupAdmin
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int UserId { get; set; }

    public DateTime? AssignedDay { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
