using KiracuFlyerAPI.DBContext;
using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;
using KiracuFlyerAPI.Request;

namespace KiracuFlyerAPI.Repository
{
    public class ChannelIconMasterRepository : IChannelIconMasterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ChannelIconMasterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateChannelIconMaster(CreateChannelIconMasterRequest request)
        {
            // リクエストからChannelIconMasterエンティティを作成
            var channelIconMaster = new ChannelIconMaster
            {
                // TODO: 各プロパティにリクエストの値をマッピング
            };

            _dbContext.ChannelIconMasters.Add(channelIconMaster);
            _dbContext.SaveChanges();

            return channelIconMaster.Level; // Levelが主キーなのでLevelを返す
        }

        public void DeleteChannelIconMaster(int iconId)
        {
            var channelIconMaster = _dbContext.ChannelIconMasters.Find(iconId);
            if (channelIconMaster == null)
            {
                // TODO: 例外処理を実装
                throw new Exception("ChannelIconMaster not found.");
            }

            _dbContext.ChannelIconMasters.Remove(channelIconMaster);
            _dbContext.SaveChanges();
        }

        public ChannelIconMaster GetChannelIconMaster(int iconId)
        {
            return _dbContext.ChannelIconMasters.Find(iconId);
        }

        public void UpdateChannelIconMaster(int iconId, UpdateChannelIconMasterRequest request)
        {
            var channelIconMaster = _dbContext.ChannelIconMasters.Find(iconId);
            if (channelIconMaster == null)
            {
                // TODO: 例外処理を実装
                throw new Exception("ChannelIconMaster not found.");
            }

            // TODO: リクエストの値をChannelIconMasterエンティティにマッピング

            _dbContext.SaveChanges();
        }
    }
}
