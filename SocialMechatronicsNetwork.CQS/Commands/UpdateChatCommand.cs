

using MediatR;
using SocialMechatronicsNetwork.Core.DTO;

namespace SocialMechatronicsNetwork.CQS.Commands
{
    public class UpdateChatCommand: IRequest<int>
    {
        public ChatDTO ChatDTO { get; set; }
    }
}
