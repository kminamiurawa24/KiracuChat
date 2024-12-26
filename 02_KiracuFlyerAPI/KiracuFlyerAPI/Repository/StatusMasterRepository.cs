using KiracuFlyerAPI.DBContext;
using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace KiracuFlyerAPI.Repository
{
    public class StatusMasterRepository : IStatusMasterRepository
    {
        private readonly ApplicationDbContext _context;

        public StatusMasterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StatusMaster>> GetAllAsync()
        {
            return await _context.StatusMasters.ToListAsync();
        }

        public async Task<StatusMaster?> GetByIdAsync(int id)
        {
            return await _context.StatusMasters.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
