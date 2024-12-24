namespace SocialMechatronicsNetwork.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
