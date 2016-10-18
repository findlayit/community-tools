using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FlexProviders.Membership;

namespace CommunityTools.Domain.Users
{
    [Table("Users")]
    public class UserEntity : BaseEntity, IFlexMembershipUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<RoleEntity> Roles { get; set; }
        [NotMapped]
        public ICollection<FlexOAuthAccount> OAuthAccounts { get; set; }

        [NotMapped]
        public string PasswordResetToken { get; set; }

        [NotMapped]
        public DateTime PasswordResetTokenExpiration { get; set; }
    }
}