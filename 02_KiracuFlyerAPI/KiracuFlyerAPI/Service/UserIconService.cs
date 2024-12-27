using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;
using KiracuFlyerAPI.Request;
using KiracuFlyerAPI.Service.Interface;

namespace KiracuFlyerAPI.Service
{
    public class UserIconService : IUserIconService
    {
        private readonly IUserIconRepository _userIconRepository;

        public UserIconService(IUserIconRepository userIconRepository)
        {
            _userIconRepository = userIconRepository;
        }

        public int CreateUserIcon(CreateUserIconRequest request)
        {
            // TODO: 必要に応じて、リクエストのバリデーションや加工を行う

            return _userIconRepository.CreateUserIcon(request);
        }

        public void DeleteUserIcon(int iconId)
        {
            _userIconRepository.DeleteUserIcon(iconId);
        }

        public UserIcon GetUserIcon(int iconId)
        {
            return _userIconRepository.GetUserIcon(iconId);
        }

        public void UpdateUserIcon(int iconId, UpdateUserIconRequest request)
        {
            // TODO: 必要に応じて、リクエストのバリデーションや加工を行う

            _userIconRepository.UpdateUserIcon(iconId, request);
        }
    }
}