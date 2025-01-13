using MediatR;
using SocialMechatronicsNetwork.Core.DTO;

namespace SocialMechatronicsNetwork.CQS.Queries
{
    public class GetChatByIdQuery: IRequest<ChatDTO>
    {
        public int Id { get; set; }
    }
}
