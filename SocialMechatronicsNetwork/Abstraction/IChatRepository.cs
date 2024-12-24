using SocialMechatronicsNetwork.Core.DTO;

namespace SocialMechatronicsNetwork.Abstraction
{
    public interface IChatRepository
    {
        public Task<List<ChatDTO>> GetAllAsync();
        public Task<int> RemoveAsync(ChatDTO chat);
        public Task<int> AddAsync(ChatDTO chat);
        public Task<int> UpdateAsync(ChatDTO chat);  
    }
}
