
using MediatR;
using SocialMechatronicsNetwork.Core.DTO;

namespace SocialMechatronicsNetwork.CQS.Commands
{
    public class AddChatCommand: IRequest<ChatDTO>
    {
        public ChatDTO chatDTO; 
    }
}
