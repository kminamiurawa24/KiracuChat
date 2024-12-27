using KiracuFlyerAPI.DBContext;
using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace KiracuFlyerAPI.Repository
{
    public class UserStatusRepository : IUserStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public UserStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserStatus?> GetByIdAsync(int id)
        {
            return await _context.UserStatuses.FindAsync(id);
        }

        public async Task AddAsync(UserStatus userStatus)
        {
            _context.UserStatuses.Add(userStatus);
            await _context.SaveChangesAsync();
        }

        public async Task<UserStatus?> GetByUserIdAsync(int userId)
        {
            return await _context.UserStatuses.FirstOrDefaultAsync(us => us.UserId == userId);
        }

        public async Task UpdateAsync(UserStatus userStatus)
        {
            _context.UserStatuses.Update(userStatus);
            await _context.SaveChangesAsync();
        }
    }
}