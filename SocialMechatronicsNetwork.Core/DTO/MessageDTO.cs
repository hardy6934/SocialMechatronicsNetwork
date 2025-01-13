
namespace SocialMechatronicsNetwork.Core.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsReaded { get; set; }

        public int AccountId { get; set; } 
        public int ChatId { get; set; } 
    }
}
