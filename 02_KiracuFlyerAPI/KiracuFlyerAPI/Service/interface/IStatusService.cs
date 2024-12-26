using KiracuFlyerAPI.Model;

namespace KiracuFlyerAPI.Service.Interface
{
    public interface IStatusService
    {
        Task<List<StatusMaster>> GetAllAsync();
    }
}
