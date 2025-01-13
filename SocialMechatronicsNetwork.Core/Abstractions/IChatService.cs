using SocialMechatronicsNetwork.Core.DTO;

namespace SocialMechatronicsNetwork.Core.Abstractions
{
    public interface IChatService
    {
        public Task<List<ChatDTO>> GetAllAsync();
        public Task<int> RemoveAsync(int Id);
        public Task<ChatDTO> AddAsync(ChatDTO chat);
        public Task<int> UpdateAsync(ChatDTO chat);
        public Task<ChatDTO> GetChatById(int Id); 
    }
}
