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
        private readonly IStatusMasterRepository _statusMasterRepository;

        public StatusService(IStatusMasterRepository statusMasterRepository)
        {
            _statusMasterRepository = statusMasterRepository;
        }

        public async Task<List<StatusMaster>> GetAllAsync()
        {
            return await _statusMasterRepository.GetAllAsync();
        }

        public async Task<StatusMaster?> GetByIdAsync(int statusId)
        {
            return await _statusMasterRepository.GetByIdAsync(statusId);
        }
    }
}
