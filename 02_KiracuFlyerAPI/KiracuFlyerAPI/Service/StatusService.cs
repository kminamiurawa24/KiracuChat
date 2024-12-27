using KiracuFlyerAPI.DBContext;
using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository;
using KiracuFlyerAPI.Repository.Interface;
using KiracuFlyerAPI.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace KiracuFlyerAPI.Service
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusMasterRepository;

        public StatusService(IStatusRepository statusMasterRepository)
        {
            _statusMasterRepository = statusMasterRepository;
        }

        public async Task<List<Status>> GetAllAsync()
        {
            return await _statusMasterRepository.GetAllAsync();
        }

        public async Task<Status?> GetByIdAsync(int statusId)
        {
            return await _statusMasterRepository.GetByIdAsync(statusId);
        }
    }
}
