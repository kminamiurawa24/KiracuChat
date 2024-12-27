using KiracuFlyerAPI.Model;

namespace KiracuFlyerAPI.Service.Interface
{
    public interface IStatusService
    {
        Task<List<Status>> GetAllAsync();
        Task<Status?> GetByIdAsync(int statusId);
    }
}
