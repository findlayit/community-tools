using System.Collections.Generic;
using CommunityTools.BusinessProvider.Models.Forums;

namespace CommunityTools.BusinessProviders.Forums
{
    public interface IForumThreadManager
    {
        List<ForumThread> FindAll();
        ForumThread FindById(int id);
        void Add(ForumThread item);
        void Update(ForumThread item);
        void Remove(ForumThread item);
        void Delete(ForumThread item);
        List<ForumThread> FindByForumId(int forumId);
        ForumThread FindByUrl(string forumUrlName,string urlName);
        List<ForumThread> FindByForumUrl(string urlName);
    }
}