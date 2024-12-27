namespace KiracuFlyerAPI.Request
{
    public class UpdateUserStatusRequest
    {
        public string CustomMessage { get; internal set; }
        public int StatusId { get; internal set; }
    }
}