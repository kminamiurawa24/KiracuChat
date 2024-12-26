using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Request;
using KiracuFlyerAPI.Service;

namespace KiracuFlyerAPI.Service.Interface
{
    public interface IUserStatusService
    {
        Task<UserStatus?> GetByUserIdAsync(int userId);
        Task UpdateUserStatusAsync(UserStatus userStatus);
    }
}
