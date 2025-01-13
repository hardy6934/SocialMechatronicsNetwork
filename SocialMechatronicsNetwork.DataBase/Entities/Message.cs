using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMechatronicsNetwork.Entities
{
    public class Message
    {
        public int Id { get; set; } 
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsReaded { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
