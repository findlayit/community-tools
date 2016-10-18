using System.Collections.Generic;
using CommunityTools.BusinessProvider.Models.Forums;

namespace CommunityTools.BusinessProviders.Forums
{
    public interface IForumManager
    {
        List<Forum> FindAll();
        Forum FindById(int id);
        void Add(Forum item);
        void Update(Forum item);
        void Remove(Forum item);
        void Delete(Forum item);
        Forum FindByUrl(string urlName);
    }
}