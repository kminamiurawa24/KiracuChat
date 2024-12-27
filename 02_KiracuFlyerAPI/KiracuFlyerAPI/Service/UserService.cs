using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository;
using KiracuFlyerAPI.Repository.Interface;
using KiracuFlyerAPI.Request;
using KiracuFlyerAPI.Service.Interface;
using Microsoft.CodeAnalysis.Scripting;

namespace KiracuFlyerAPI.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            // バリデーション処理など
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            // バリデーション処理など
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User> AuthenticateUserAsync(LoginRequest loginRequest)
        {
            var user = await _userRepository.GetByLoginIdAsync(loginRequest.LoginId);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password,user.Password)) // パスワードの検証
            {
                return null; // 認証失敗
            }
            return user; // 認証成功
        }
    }
}
