using KiracuFlyerAPI.DBContext;
using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Repository.Interface;
using KiracuFlyerAPI.Request;

namespace KiracuFlyerAPI.Repository
{
    public class UserIconRepository : IUserIconRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserIconRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateUserIcon(CreateUserIconRequest request)
        {
            // リクエストからUserIconエンティティを作成
            var userIcon = new UserIcon
            {
                // TODO: 各プロパティにリクエストの値をマッピング
            };

            _dbContext.UserIcons.Add(userIcon);
            _dbContext.SaveChanges();

            return userIcon.Id;
        }

        public void DeleteUserIcon(int iconId)
        {
            var userIcon = _dbContext.UserIcons.Find(iconId);
            if (userIcon == null)
            {
                // TODO: 例外処理を実装
                throw new Exception("UserIcon not found.");
            }

            _dbContext.UserIcons.Remove(userIcon);
            _dbContext.SaveChanges();
        }

        public UserIcon GetUserIcon(int iconId)
        {
            return _dbContext.UserIcons.Find(iconId);
        }

        public void UpdateUserIcon(int iconId, UpdateUserIconRequest request)
        {
            var userIcon = _dbContext.UserIcons.Find(iconId);
            if (userIcon == null)
            {
                // TODO: 例外処理を実装
                throw new Exception("UserIcon not found.");
            }

            // TODO: リクエストの値をUserIconエンティティにマッピング

            _dbContext.SaveChanges();
        }
    }
}