using AutoMapper;
using SocialMechatronicsNetwork.Core.DTO;
using SocialMechatronicsNetwork.Entities;

namespace SocialMechatronicsNetwork.MappingProfiles
{
    public class ChatProfile: Profile
    {
        public ChatProfile()
        {

            CreateMap<Chat, ChatDTO>(); 
            CreateMap<ChatDTO, Chat>();  
             
        }
    }
}
