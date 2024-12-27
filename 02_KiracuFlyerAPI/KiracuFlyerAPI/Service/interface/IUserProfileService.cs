using KiracuFlyerAPI.Model;

namespace KiracuFlyerAPI.Service.Interface
{
    public interface IUserProfileService
    {
        // ユーザープロフィールを作成
        int CreateUserProfile(UserProfile userProfile);

        // 特定のユーザープロフィールを取得
        UserProfile GetUserProfile(int userId);

        // 特定のユーザープロフィールを更新
        void UpdateUserProfile(UserProfile userProfile);

        // 特定のユーザープロフィールを削除
        void DeleteUserProfile(int userId);
    }
}
