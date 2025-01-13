using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMechatronicsNetwork.Core.DTO;
using SocialMechatronicsNetwork.CQS.Queries;
using SocialMechatronicsNetwork.DataBase;

namespace SocialMechatronicsNetwork.CQS.Handlers.QueryHandlers
{
    public class GetChatByIdQueryHandler : IRequestHandler<GetChatByIdQuery, ChatDTO>
    {
        private readonly SocialMechatronicsNetworkContext context; 
        private readonly IMapper mapper;
        public GetChatByIdQueryHandler(SocialMechatronicsNetworkContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<ChatDTO> Handle(GetChatByIdQuery request, CancellationToken cancellationToken)
        {
            var ent = await context.Chats.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
            return mapper.Map<ChatDTO>(ent); 
        }
    }
}
