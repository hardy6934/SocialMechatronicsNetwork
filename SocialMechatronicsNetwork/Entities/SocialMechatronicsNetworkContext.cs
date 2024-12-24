using Microsoft.EntityFrameworkCore; 

namespace SocialMechatronicsNetwork.Entities
{
    public class SocialMechatronicsNetworkContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; } 
        public DbSet<Chat> Chats { get; set; } 
        public DbSet<ChatUser> ChatUsers { get; set; } 
        public DbSet<Message> Messages { get; set; }
         
        public SocialMechatronicsNetworkContext(DbContextOptions<SocialMechatronicsNetworkContext> options)
            : base(options)
        {

        }
    }
}
