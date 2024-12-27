using KiracuFlyerAPI.DBContext;
using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;

namespace KiracuFlyerAPI.Repository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RefreshTokenRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateRefreshToken(RefreshToken refreshToken)
        {
            _dbContext.RefreshTokens.Add(refreshToken);
            _dbContext.SaveChanges();
        }

        public void DeleteRefreshToken(int userId)
        {
            var refreshToken = _dbContext.RefreshTokens.Find(userId);
            if (refreshToken == null)
            {
                // TODO: 例外処理を実装
                throw new Exception("RefreshToken not found.");
            }

            _dbContext.RefreshTokens.Remove(refreshToken);
            _dbContext.SaveChanges();
        }

        public RefreshToken GetRefreshTokenByUserId(int userId)
        {
            return _dbContext.RefreshTokens.Find(userId);
        }

        public void UpdateRefreshToken(RefreshToken refreshToken)
        {
            _dbContext.RefreshTokens.Update(refreshToken);
            _dbContext.SaveChanges();
        }
    }
}
