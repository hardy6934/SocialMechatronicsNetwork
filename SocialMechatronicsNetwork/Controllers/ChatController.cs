using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMechatronicsNetwork.Core.Abstractions;
using SocialMechatronicsNetwork.Core.DTO;
using SocialMechatronicsNetwork.Entities;
using System;

namespace SocialMechatronicsNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService chatService;
        public ChatController(IChatService chatService) {
            this.chatService = chatService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChatsForAccountAsync() {
             
            var DTOs = await chatService.GetAllAsync();
            return Ok(DTOs);

        }

        [HttpPost]
        public async Task<IActionResult> CreateChatAsync(int accountId) {
                
            var chatDTO = new ChatDTO()
            {
                CreatedAt = DateTime.UtcNow
            };
             
            return Ok(await chatService.AddAsync(chatDTO)); 
             
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChat(int id) {

            if (id > 0)
            { 
                var res = await chatService.RemoveAsync(id);
                return Ok(res); 
            }
            return BadRequest();
        }
    }
}
