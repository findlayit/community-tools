using System.Collections.Generic;
using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Forums;
using System.Data.Entity;
using System.Linq;

namespace CommunityTools.DataAccess.Forums
{
    public class ForumPostRepository : BaseRepository<ForumPostEntity>, IForumPostRepository
    {
        public ForumPostRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<ForumPostEntity> FindByThreadUrl(string forumUrlName, string threadUrlName)
        {
            return _unitOfWork.Set<ForumPostEntity>()
                .Include(o => o.ForumThread)
                .Include(o => o.ForumThread.Forum)
                .Where(o => o.ForumThread.Forum.UrlName.ToLower()==forumUrlName.ToLower() && o.ForumThread.UrlName.ToLower() == threadUrlName.ToLower())
                .OrderBy(o => o.CreatedDateTime)
                .ToList();
        }
        public string FetchFullUrl(int id)
        {
            var entity = _unitOfWork.Set<ForumPostEntity>()
                .Include(o => o.ForumThread)
                .Include(o => o.ForumThread.Forum)
                .Include(o => o.ForumThread.Forum.ForumGroup)
                .Single(o => o.Id == id);
            return
                $"{entity.ForumThread.Forum.ForumGroup.UrlName}/{entity.ForumThread.Forum.UrlName}/{entity.ForumThread.UrlName}";

        }
    }
}