using KiracuFlyerAPI.Model;

namespace KiracuFlyerAPI.Repository.Interface
{
    public interface IStatusMasterRepository
    {
        Task<List<StatusMaster>> GetAllAsync();
        Task<StatusMaster?> GetByIdAsync(int id);
    }
}
