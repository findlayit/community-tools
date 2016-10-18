using System.Collections.Generic;
using System.Linq;
using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Forums;
using System.Data.Entity;

namespace CommunityTools.DataAccess.Forums
{
    public class ForumThreadRepository : BaseRepository<ForumThreadEntity>, IForumThreadRepository
    {
        public ForumThreadRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        //public override IQueryable<ForumThreadEntity> FindAll()
        //{
        //    return _unitOfWork
        //        .Set<ForumThreadEntity>()
        //        .Include(o => o.Forum)
        //        .Include(o => o.ForumPosts);
        //}

        public List<ForumThreadEntity> FindByForumId(int forumId)
        {
            return _unitOfWork
                .Set<ForumThreadEntity>()
                .Include(o => o.Forum)
                .Include(o => o.ForumPosts)
                .Where(o => o.ForumId == forumId)
                .OrderByDescending(o => o.CreatedDateTime)
                .ToList();
        }
        public List<ForumThreadEntity> FindByForumUrl(string urlName)
        {
            return _unitOfWork
                .Set<ForumThreadEntity>()
                .Include(o => o.Forum)
                .Include(o => o.ForumPosts)
                .Where(o => o.Forum.UrlName.ToLower() == urlName.ToLower())
                .OrderByDescending(o => o.CreatedDateTime)
                .ToList();
        }
        public ForumThreadEntity FindByUrl(string forumUrlName, string urlName)
        {
            return _unitOfWork
                .Set<ForumThreadEntity>()
                .Include(o => o.Forum)
                .Include(o => o.ForumPosts)
                .FirstOrDefault(o => o.UrlName.ToLower() == urlName.ToLower() && o.Forum.UrlName.ToLower()==forumUrlName.ToLower());
        }
    }
}