using KiracuFlyerAPI.DBContext;
using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Service.i;
using KiracuFlyerAPI.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace KiracuFlyerAPI.Service
{
    public class StatusService : IStatusService
    {
        private readonly ApplicationDbContext _context;

        public StatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StatusMaster>> GetAllAsync()
        {
            return await _context.StatusMasters.ToListAsync();
        }
    }
}
