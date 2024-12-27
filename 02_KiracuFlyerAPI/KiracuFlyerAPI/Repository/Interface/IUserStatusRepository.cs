using KiracuFlyerAPI.Model;

namespace KiracuFlyerAPI.Repository.Interface
{
    public interface IUserStatusRepository
    {
        Task AddAsync(UserStatus userStatus);
        Task<UserStatus?> GetByUserIdAsync(int userId);
        Task UpdateAsync(UserStatus userStatus);
    }
}
