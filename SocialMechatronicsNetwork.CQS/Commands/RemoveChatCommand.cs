using MediatR;

namespace SocialMechatronicsNetwork.CQS.Commands
{
    public class RemoveChatCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
