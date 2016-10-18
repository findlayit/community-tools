using CommunityTools.Domain.Users;
using FlexProviders.EF;

namespace CommunityTools.DataAccess.Users
{
    public class UserStore : FlexMembershipUserStore<UserEntity>
    {
        public UserStore(UserContext db)
            : base(db)
        {
        }
    }
}