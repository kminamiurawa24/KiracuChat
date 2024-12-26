using KiracuFlyerAPI.DBContext;
using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace KiracuFlyerAPI.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public StatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> GetAllAsync()
        {
            return await _context.StatusMasters.ToListAsync();
        }

        public async Task<Status?> GetByIdAsync(int id)
        {
            return await _context.StatusMasters.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
