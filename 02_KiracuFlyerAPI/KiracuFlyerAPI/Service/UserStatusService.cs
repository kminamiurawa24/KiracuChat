using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository;
using KiracuFlyerAPI.Repository.Interface;
using KiracuFlyerAPI.Service.Interface;

namespace KiracuFlyerAPI.Service
{
    public class UserStatusService : IUserStatusService
    {
        private readonly IUserStatusRepository _userStatusRepository;

        public UserStatusService(IUserStatusRepository userStatusRepository)
        {
            _userStatusRepository = userStatusRepository;
        }

        public async Task<UserStatus?> GetByUserIdAsync(int userId)
        {
            return await _userStatusRepository.GetByUserIdAsync(userId);
        }

        public async Task UpdateUserStatusAsync(UserStatus userStatus)
        {
            var existingStatus = await _userStatusRepository.GetByUserIdAsync(userStatus.UserId);

            if (existingStatus == null)
            {
                // 存在しない場合は新規登録
                await _userStatusRepository.AddAsync(userStatus);
            }
            else
            {
                // 存在する場合は更新
                await _userStatusRepository.UpdateAsync(userStatus);
            }
        }
    }
}