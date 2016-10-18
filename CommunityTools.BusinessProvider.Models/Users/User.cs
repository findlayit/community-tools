using System.Collections.Generic;
using CommunityTools.BusinessProvider.Common;

namespace CommunityTools.BusinessProvider.Models.Users
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}