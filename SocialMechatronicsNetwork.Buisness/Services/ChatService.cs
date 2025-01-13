using AutoMapper;
using MediatR;
using SocialMechatronicsNetwork.Core.Abstractions;
using SocialMechatronicsNetwork.Core.DTO;
using SocialMechatronicsNetwork.CQS.Commands;
using SocialMechatronicsNetwork.CQS.Queries; 

namespace SocialMechatronicsNetwork.Buisness.Services
{
    public class ChatService : IChatService
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public ChatService(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<ChatDTO> AddAsync(ChatDTO chat)
        {
            var dto = await mediator.Send(new AddChatCommand() { 
                chatDTO = chat
            });
            return dto;           
        }

        public async Task<List<ChatDTO>> GetAllAsync()
        {
            var dTOs = await mediator.Send(new GetAllChatsQuery());
            return dTOs.ToList();
        }

        public async Task<ChatDTO> GetChatById(int Id)
        {
            return await mediator.Send(new GetChatByIdQuery() { 
                Id = Id
            }); 
        }

        public async Task<int> RemoveAsync(int Id)
        { 
            return await mediator.Send(new RemoveChatCommand() { 
                Id = Id
            });   
        }

        public async Task<int> UpdateAsync(ChatDTO dto)
        {
            if (!(dto is null) && dto.Id > 0)
            {
                return await mediator.Send(new UpdateChatCommand() {
                    ChatDTO = dto
                });
            }
            else return 0;
        }
    }
}
