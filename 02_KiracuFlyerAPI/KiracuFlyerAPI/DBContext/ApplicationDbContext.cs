using KiracuFlyerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace KiracuFlyerAPI.DBContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
