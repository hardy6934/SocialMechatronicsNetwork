
using AutoMapper;
using MediatR;
using SocialMechatronicsNetwork.CQS.Commands;
using SocialMechatronicsNetwork.DataBase;
using SocialMechatronicsNetwork.Entities;

namespace SocialMechatronicsNetwork.CQS.Handlers.CommandHandlers
{
    public class UpdateChatCommandHandler : IRequestHandler<UpdateChatCommand, int>
    {
        private readonly SocialMechatronicsNetworkContext context;
        private readonly IMapper mapper;
        public async Task<int> Handle(UpdateChatCommand request, CancellationToken cancellationToken)
        {
            context.Chats.Update(mapper.Map<Chat>(request.ChatDTO));
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
