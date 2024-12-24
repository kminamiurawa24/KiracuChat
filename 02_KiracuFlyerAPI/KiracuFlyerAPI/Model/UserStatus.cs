namespace KiracuFlyerAPI.Model
{
    public class UserStatus
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public string? CustomMessage { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
