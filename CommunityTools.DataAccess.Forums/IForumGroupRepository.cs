using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Forums;

namespace CommunityTools.DataAccess.Forums
{
    public interface IForumGroupRepository:IBaseRepository<ForumGroupEntity>
    {
        ForumGroupEntity FindByUrl(string urlName);
    }
}