using System.Collections.Generic;
using CommunityTools.BusinessProvider.Models.Forums;

namespace CommunityTools.BusinessProviders.Forums
{
    public interface IForumGroupManager
    {
        List<ForumGroup> FindAll();
        ForumGroup FindById(int id);
        void Add(ForumGroup item);
        void Update(ForumGroup item);
        void Remove(ForumGroup item);
        void Delete(ForumGroup item);
        ForumGroup FindByUrl(string urlName);
    }
}