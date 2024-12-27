using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;
using KiracuFlyerAPI.Service.Interface;

namespace KiracuFlyerAPI.Service
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public int CreateUserProfile(UserProfile userProfile)
        {
            // TODO: 必要に応じて、ユーザープロフィールのバリデーションや加工を行う

            return _userProfileRepository.CreateUserProfile(userProfile);
        }

        public void DeleteUserProfile(int userId)
        {
            _userProfileRepository.DeleteUserProfile(userId);
        }

        public UserProfile GetUserProfile(int userId)
        {
            return _userProfileRepository.GetUserProfile(userId);
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            // TODO: 必要に応じて、ユーザープロフィールのバリデーションや加工を行う

            _userProfileRepository.UpdateUserProfile(userProfile);
        }
    }
}
