namespace SocialMechatronicsNetwork.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsGroupChat { get; set; } = false;

        
        public List<ChatUser> ChatUsers { get; set; }
        public List<Message> Messages { get; set; }
    }
}
