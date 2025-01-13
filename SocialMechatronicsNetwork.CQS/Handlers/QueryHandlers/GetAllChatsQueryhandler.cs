

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMechatronicsNetwork.Core.DTO;
using SocialMechatronicsNetwork.CQS.Queries;
using SocialMechatronicsNetwork.DataBase;

namespace SocialMechatronicsNetwork.CQS.Handlers.QueryHandlers
{
    public class GetAllChatsQueryhandler : IRequestHandler<GetAllChatsQuery, ChatDTO[]>
    {
        private readonly IMapper mapper;
        private readonly SocialMechatronicsNetworkContext context;

        public GetAllChatsQueryhandler(SocialMechatronicsNetworkContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ChatDTO[]> Handle(GetAllChatsQuery request, CancellationToken cancellationToken)
        {
            var chats = await context.Chats.ToArrayAsync();
            return chats.Select(mapper.Map<ChatDTO>).ToArray();
        }
    }
}
