using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Service;

namespace KiracuFlyerAPI.Service.Interface
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
