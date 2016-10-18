using System.Collections.Generic;
using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Forums;

namespace CommunityTools.DataAccess.Forums
{
    public interface IForumThreadRepository : IBaseRepository<ForumThreadEntity>
    {
        List<ForumThreadEntity> FindByForumId(int forumId);
        ForumThreadEntity FindByUrl(string forumUrlName, string urlName);
        List<ForumThreadEntity> FindByForumUrl(string urlName);
    }
}