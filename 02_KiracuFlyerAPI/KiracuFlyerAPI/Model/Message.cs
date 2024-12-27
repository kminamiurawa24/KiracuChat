using System;
using System.Collections.Generic;

namespace KiracuFlyerAPI.Model;

public partial class Message
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? HandleName { get; set; }

    public int? MessageNo { get; set; }

    public string? Text { get; set; }

    public string? MediaUrl { get; set; }

    public DateTime? PostDate { get; set; }

    public DateTime? ModifiedDay { get; set; }

    public virtual User User { get; set; } = null!;
}
