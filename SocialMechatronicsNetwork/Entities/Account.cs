namespace SocialMechatronicsNetwork.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string CreatedAt { get; set; }
        public string? FilePath { get; set; }

        public string Login {  get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Message> Messages { get; set; } 
        public List<ChatUser> ChatUsers { get; set; } 
        
    }
}
