using KiracuFlyerAPI.DBContext;
using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;

namespace KiracuFlyerAPI.Repository
{
    public class UserProfileRepository: IUserProfileRepository  
    {
        private readonly ApplicationDbContext _dbContext;

        public UserProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateUserProfile(UserProfile userProfile)
        {
            _dbContext.UserProfiles.Add(userProfile);
            _dbContext.SaveChanges();
            return userProfile.Id;
        }

        public void DeleteUserProfile(int userId)
        {
            var userProfile = _dbContext.UserProfiles.Find(userId);
            if (userProfile == null)
            {
                // TODO: 例外処理を実装
                throw new Exception("UserProfile not found.");
            }

            _dbContext.UserProfiles.Remove(userProfile);
            _dbContext.SaveChanges();
        }

        public UserProfile GetUserProfile(int userId)
        {
            return _dbContext.UserProfiles.Find(userId);
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            _dbContext.UserProfiles.Update(userProfile);
            _dbContext.SaveChanges();
        }
    }
}
