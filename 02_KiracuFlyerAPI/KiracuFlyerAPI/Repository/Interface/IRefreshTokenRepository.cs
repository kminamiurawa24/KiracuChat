using KiracuFlyerAPI.Model;

namespace KiracuFlyerAPI.Repository.Interface
{
    public interface IRefreshTokenRepository
    {
        // リフレッシュトークンを作成
        void CreateRefreshToken(RefreshToken refreshToken);

        // 特定のユーザーのリフレッシュトークンを取得
        RefreshToken GetRefreshTokenByUserId(int userId);

        // リフレッシュトークンを更新
        void UpdateRefreshToken(RefreshToken refreshToken);

        // リフレッシュトークンを削除
        void DeleteRefreshToken(int userId);
    }
}
