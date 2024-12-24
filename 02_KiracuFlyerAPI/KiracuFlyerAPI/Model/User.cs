namespace KiracuFlyerAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? LoginId { get; set; }
        public string? Password { get; set; }
        public string? Name {  get; set; }
        public bool IsActive { get; set; }
        public int StatusId { get; set; }
        public string? StatusMessage {  get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int UserLevel {  get; set; }

        public UserStatus? Status { get; set; }
        public UserBatch? Batch { get; set; }
        public UserIcon? Icon { get; set; }
        public UserProfile? Profile { get; set; }
    }
}
