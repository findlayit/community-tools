using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Forums;

namespace CommunityTools.DataAccess.Forums
{
    public interface IForumRepository : IBaseRepository<ForumEntity>
    {
        ForumEntity FindByUrl(string urlName);
    }
}