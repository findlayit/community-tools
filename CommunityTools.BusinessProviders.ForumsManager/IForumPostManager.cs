using System.Collections.Generic;
using CommunityTools.BusinessProvider.Models.Forums;

namespace CommunityTools.BusinessProviders.Forums
{
    public interface IForumPostManager
    {
        List<ForumPost> FindAll();
        ForumPost FindById(int id);
        void Add(ForumPost item);
        void Update(ForumPost item);
        void Remove(ForumPost item);
        void Delete(ForumPost item);
        string FetchFullUrl(int id);
        List<ForumPost> FindByThreadUrl(string forumUrlName, string threadUrlName);
    }
}