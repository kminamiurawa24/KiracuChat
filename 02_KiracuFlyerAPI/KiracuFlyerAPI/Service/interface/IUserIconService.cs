using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Request;

namespace KiracuFlyerAPI.Service.Interface
{
    public interface IUserIconService
    {
        // ユーザーアイコンを作成
        int CreateUserIcon(CreateUserIconRequest request);

        // 特定のユーザーアイコンを取得
        UserIcon GetUserIcon(int iconId);

        // 特定のユーザーアイコンを更新
        void UpdateUserIcon(int iconId, UpdateUserIconRequest request);

        // 特定のユーザーアイコンを削除
        void DeleteUserIcon(int iconId);
    }
}
