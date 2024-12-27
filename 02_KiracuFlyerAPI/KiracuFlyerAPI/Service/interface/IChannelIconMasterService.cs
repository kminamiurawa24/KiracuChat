using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Request;

namespace KiracuFlyerAPI.Service.Interface
{
    public interface IChannelIconMasterService
    {
        // チャンネルアイコンマスターを作成
        int CreateChannelIconMaster(CreateChannelIconMasterRequest request);

        // 特定のチャンネルアイコンマスターを取得
        ChannelIconMaster GetChannelIconMaster(int iconId);

        // 特定のチャンネルアイコンマスターを更新
        void UpdateChannelIconMaster(int iconId, UpdateChannelIconMasterRequest request);

        // 特定のチャンネルアイコンマスターを削除
        void DeleteChannelIconMaster(int iconId);
    }
}
