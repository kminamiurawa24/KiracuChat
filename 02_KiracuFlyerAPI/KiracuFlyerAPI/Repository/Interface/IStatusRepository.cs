using KiracuFlyerAPI.Model;

namespace KiracuFlyerAPI.Repository.Interface
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllAsync();
        Task<Status?> GetByIdAsync(int id);
    }
}
