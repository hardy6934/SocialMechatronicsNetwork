using SocialMechatronicsNetwork.Entities;

namespace SocialMechatronicsNetwork.Core.DTO
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsGroupChat { get; set; }

        public List<MessageDTO> MessagesDTO { get; set; }
        public List<ChatUserDTO> ChatUsersDTO { get; set; }
    }
}
