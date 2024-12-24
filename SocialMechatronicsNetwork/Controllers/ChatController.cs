using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMechatronicsNetwork.Core.DTO;
using SocialMechatronicsNetwork.Entities;

namespace SocialMechatronicsNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly SocialMechatronicsNetworkContext context;
        public ChatController(SocialMechatronicsNetworkContext context) {
            this.context = context; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChatsForAccountAsync(int accountId) {

            var account = await context.Accounts
                .Include(x=>x.ChatUsers)
                .ThenInclude(x=>x.Chat)
                .FirstOrDefaultAsync(x => x.Id == accountId);

            if (account != null)
            {
                List<ChatDTO> chats = new();
                foreach (var n in account.ChatUsers)
                {
                    chats.Add(new ChatDTO { Id = n.Id, IsGroupChat = n.Chat.IsGroupChat, CreatedAt = n.Chat.CreatedAt});
                }

                return Ok(chats);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChatAsync(int accountId) {

            var chat = new Chat()
            {
                CreatedAt = DateTime.UtcNow
            };
            await context.Chats.AddAsync(chat);
            await context.SaveChangesAsync();

            if (chat.Id > 0 && await context.Accounts.AnyAsync(x => x.Id.Equals(accountId)))
            {
                var chatUser = new ChatUser()
                {
                    JoinedAt = DateTime.UtcNow,
                    ChatId = chat.Id,
                    AccountId = accountId,
                };
                await context.ChatUsers.AddAsync(chatUser);
                var res = await context.SaveChangesAsync();

                if (res > 0)
                {
                    return Ok(new ChatUser {Id = chatUser.Id, JoinedAt = chatUser.JoinedAt, AccountId = chatUser.AccountId, ChatId = chatUser.ChatId,
                        Chat = new Chat { Id = chatUser.Chat.Id, CreatedAt = chatUser.Chat.CreatedAt, IsGroupChat = chatUser.Chat.IsGroupChat} }); 
                }
                else return BadRequest();
            }
            else return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChat(int id) {

            if (id > 0)
            {
                var ent = await context.Chats.FirstOrDefaultAsync(x => x.Id.Equals(id)); 
                if (ent != null) {
                    var deletedEntity = context.Chats.Remove(ent);
                    var res = await context.SaveChangesAsync();

                    if(res > 0)
                    {
                        return Ok(deletedEntity);
                    }
                }
                return NotFound();
            } 
            return BadRequest();
        }
    }
}
