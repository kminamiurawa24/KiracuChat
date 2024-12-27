using System;
using System.Collections.Generic;

namespace KiracuFlyerAPI.Model;

public partial class Channel
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public string Title { get; set; } = null!;

    public int CreatedUserId { get; set; }

    public DateTime? CreatedDay { get; set; }

    public DateTime? ModifiedDay { get; set; }

    public int? Level { get; set; }

    public string Description { get; set; } = null!;

    public virtual User CreatedUser { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;
}
