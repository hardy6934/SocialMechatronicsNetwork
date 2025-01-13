using AutoMapper;
using MediatR;
using SocialMechatronicsNetwork.Core.DTO;
using SocialMechatronicsNetwork.CQS.Commands;
using SocialMechatronicsNetwork.DataBase;
using SocialMechatronicsNetwork.Entities; 

namespace SocialMechatronicsNetwork.CQS.Handlers.CommandHandlers
{
    public class AddChatCommandHandler : IRequestHandler<AddChatCommand, ChatDTO>
    {
        private readonly SocialMechatronicsNetworkContext context;
        private readonly IMapper mapper;
        public AddChatCommandHandler(SocialMechatronicsNetworkContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
         

        public async Task<ChatDTO> Handle(AddChatCommand request, CancellationToken cancellationToken)
        { 
            var entEntry = await context.Chats.AddAsync(mapper.Map<Chat>(request.chatDTO));
            await context.SaveChangesAsync(cancellationToken);
            return mapper.Map<ChatDTO>(entEntry.Entity);
              
        }
    }


}
