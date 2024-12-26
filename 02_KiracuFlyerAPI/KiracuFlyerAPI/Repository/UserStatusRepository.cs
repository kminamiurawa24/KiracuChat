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

        public async Task UpsertAsync(UserStatus userStatus)
        {
            var existingStatus = await _context.UserStatuses
                .FirstOrDefaultAsync(s => s.UserId == userStatus.UserId);

            if (existingStatus == null)
            {
                // 存在しない場合は新規登録
                _context.UserStatuses.Add(userStatus);
            }
            else
            {
                // 存在する場合は更新
                existingStatus.StatusId = userStatus.StatusId;
                existingStatus.CustomMessage = userStatus.CustomMessage;
                existingStatus.UpdatedAt = userStatus.UpdatedAt;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<UserStatus?> GetByIdAsync(int id)
        {
            return await _context.UserStatuses.FindAsync(id);
        }
    }
}
