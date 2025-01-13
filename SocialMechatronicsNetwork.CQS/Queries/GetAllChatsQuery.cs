using MediatR;
using SocialMechatronicsNetwork.Core.DTO;

namespace SocialMechatronicsNetwork.CQS.Queries
{
    public class GetAllChatsQuery: IRequest<ChatDTO[]>
    {

    }
}
