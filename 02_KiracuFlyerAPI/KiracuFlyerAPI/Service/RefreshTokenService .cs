using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;
using KiracuFlyerAPI.Service.Interface;

namespace KiracuFlyerAPI.Service
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public void CreateRefreshToken(RefreshToken refreshToken)
        {
            // TODO: 必要に応じて、リフレッシュトークンのバリデーションや加工を行う

            _refreshTokenRepository.CreateRefreshToken(refreshToken);
        }

        public void DeleteRefreshToken(int userId)
        {
            _refreshTokenRepository.DeleteRefreshToken(userId);
        }

        public RefreshToken GetRefreshTokenByUserId(int userId)
        {
            return _refreshTokenRepository.GetRefreshTokenByUserId(userId);
        }

        public void UpdateRefreshToken(RefreshToken refreshToken)
        {
            // TODO: 必要に応じて、リフレッシュトークンのバリデーションや加工を行う

            _refreshTokenRepository.UpdateRefreshToken(refreshToken);
        }
    }
}
