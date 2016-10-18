namespace CommunityTools.BusinessProvider.Models.Users
{
    public class AuthenticationModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
        public string AccessToken { get; set; }
    }
}