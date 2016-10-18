using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Users;

namespace CommunityTools.DataAccess.Users
{
    public class RoleRepository : BaseRepository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}