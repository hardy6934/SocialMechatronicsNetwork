using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMechatronicsNetwork.Abstraction;
using SocialMechatronicsNetwork.Core.DTO;
using SocialMechatronicsNetwork.Entities;
using System;

namespace SocialMechatronicsNetwork.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly IMapper mapper;
        private readonly DbSet<Chat> Chats;
        private readonly SocialMechatronicsNetworkContext context;
        public ChatRepository(SocialMechatronicsNetworkContext context, IMapper mapper )
        {
            Chats = context.Chats;
            this.context = context;
            this.mapper = mapper;
        } 
        public async Task<int> AddAsync(ChatDTO chat)
        {
            await Chats.AddAsync(mapper.Map<Chat>(chat));
            return await context.SaveChangesAsync();
        }

        public async Task<List<ChatDTO>> GetAllAsync()
        {
            var entities = await Chats.ToListAsync();
            return entities.Select(mapper.Map<ChatDTO>).ToList();
        }

        public async Task<int> RemoveAsync(ChatDTO chat)
        {  
            Chats.Remove(mapper.Map<Chat>(chat));
            return await context.SaveChangesAsync(); 
        } 

        public async Task<int> UpdateAsync(ChatDTO chat)
        {
            Chats.Update(mapper.Map<Chat>(chat));
            return await context.SaveChangesAsync();
        }
    }
}
