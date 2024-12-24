namespace SocialMechatronicsNetwork.Entities
{
    public class ChatUser
    {
        public int Id { get; set; }
        public DateTime JoinedAt { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }

        
    }
}
