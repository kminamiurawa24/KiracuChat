using System;
using System.Collections.Generic;

namespace KiracuFlyerAPI.Model;

public partial class User
{
    public int Id { get; set; }

    public string LoginId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDay { get; set; }

    public int? UserLevel { get; set; }

    public int? UserIconId { get; set; }

    public byte? IsDeleted { get; set; }

    public virtual ICollection<Channel> Channels { get; set; } = new List<Channel>();

    public virtual ICollection<GroupAdmin> GroupAdmins { get; set; } = new List<GroupAdmin>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual UserIcon? UserIcon { get; set; }

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

    public virtual ICollection<UserStatus> UserStatuses { get; set; } = new List<UserStatus>();
}
