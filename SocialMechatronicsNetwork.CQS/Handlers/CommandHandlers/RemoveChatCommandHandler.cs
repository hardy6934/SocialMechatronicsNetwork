using MediatR;
using SocialMechatronicsNetwork.CQS.Commands;
using SocialMechatronicsNetwork.DataBase;

namespace SocialMechatronicsNetwork.CQS.Handlers.CommandHandlers
{
    public class RemoveChatCommandHandler : IRequestHandler<RemoveChatCommand, int>
    {
        private readonly SocialMechatronicsNetworkContext context; 

        public RemoveChatCommandHandler(SocialMechatronicsNetworkContext context)
        { 
            this.context = context;
        }

        public async Task<int> Handle(RemoveChatCommand request, CancellationToken cancellationToken)
        {
            var ent = context.Chats.FirstOrDefault(c => c.Id == request.Id);
            if (ent != null)
            {
                context.Chats.Remove(ent);
                return await context.SaveChangesAsync(cancellationToken);
            }
            else return 0;
        }
    }
}
