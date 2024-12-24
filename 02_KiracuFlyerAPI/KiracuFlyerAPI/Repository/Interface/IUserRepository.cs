using KiracuFlyerAPI.Model;

namespace KiracuFlyerAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByLoginIdAsync(string loginId);
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
