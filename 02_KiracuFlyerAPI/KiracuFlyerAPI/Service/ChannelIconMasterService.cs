using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;
using KiracuFlyerAPI.Request;
using KiracuFlyerAPI.Service.Interface;

namespace KiracuFlyerAPI.Service
{
    public class ChannelIconMasterService : IChannelIconMasterService
    {
        private readonly IChannelIconMasterRepository _channelIconMasterRepository;

        public ChannelIconMasterService(IChannelIconMasterRepository channelIconMasterRepository)
        {
            _channelIconMasterRepository = channelIconMasterRepository;
        }

        public int CreateChannelIconMaster(CreateChannelIconMasterRequest request)
        {
            // TODO: 必要に応じて、リクエストのバリデーションや加工を行う

            return _channelIconMasterRepository.CreateChannelIconMaster(request);
        }

        public void DeleteChannelIconMaster(int iconId)
        {
            _channelIconMasterRepository.DeleteChannelIconMaster(iconId);
        }

        public ChannelIconMaster GetChannelIconMaster(int iconId)
        {
            return _channelIconMasterRepository.GetChannelIconMaster(iconId);
        }

        public void UpdateChannelIconMaster(int iconId, UpdateChannelIconMasterRequest request)
        {
            // TODO: 必要に応じて、リクエストのバリデーションや加工を行う

            _channelIconMasterRepository.UpdateChannelIconMaster(iconId, request);
        }
    }
}
