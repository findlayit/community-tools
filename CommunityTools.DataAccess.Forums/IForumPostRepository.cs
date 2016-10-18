using System.Collections.Generic;
using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Forums;

namespace CommunityTools.DataAccess.Forums
{
    public interface IForumPostRepository : IBaseRepository<ForumPostEntity>
    {
        string FetchFullUrl(int id);
        List<ForumPostEntity> FindByThreadUrl(string forumUrlName, string threadUrlName);
    }
}