using KiracuFlyerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace KiracuFlyerAPI.DBContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserStatus> UserStatuses { get; internal set; }
        public DbSet<Status> Statuses { get; internal set; }

    }
}
