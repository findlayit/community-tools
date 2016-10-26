using System.Collections.Generic;
using System.Linq;
using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Forums;
using System.Data.Entity;

namespace CommunityTools.DataAccess.Forums
{
    public class ForumGroupRepository : BaseRepository<ForumGroupEntity>, IForumGroupRepository
    {
        public ForumGroupRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override IEnumerable<ForumGroupEntity> FindAll()
        {
            var list = _unitOfWork.Set<ForumGroupEntity>();
            var threads = _unitOfWork.Set<ForumThreadEntity>();
            var posts = _unitOfWork.Set<ForumPostEntity>()
                .Include(o => o.ForumThread)
                .GroupBy(o => o.ForumThread.ForumId)
                .Select(group => new
                {
                    ForumId = group.Key,
                    PostCount = group.Count(),
                    LastPost = group.OrderByDescending(p => p.CreatedDateTime).FirstOrDefault()
                }).ToList();

            var forums = _unitOfWork.Set<ForumEntity>().ToList()
                .Select(o => new ForumEntity()
                {
                    Title = o.Title,
                    UrlName = o.UrlName,
                    Description = o.Description,
                    ForumGroupId = o.ForumGroupId,
                    ForumGroup = o.ForumGroup,
                    ThreadCount = threads.Count(t => t.ForumId == o.Id),
                    PostCount =
                        posts.FirstOrDefault(p => p.ForumId == o.Id) != null
                            ? posts.First(p => p.ForumId == o.Id).PostCount
                            : 0,
                    LastPost = posts.FirstOrDefault(p => p.ForumId == o.Id) != null
                        ? posts.First(p => p.ForumId == o.Id).LastPost
                        : null
                });


            return list.ToList().Select(o => new ForumGroupEntity()
            {
                Id = o.Id,
                CreatedBy = o.CreatedBy,
                CreatedDateTime = o.CreatedDateTime,
                IsDeleted = o.IsDeleted,
                Title = o.Title,
                UrlName = o.UrlName,
                Forums = forums.Where(x => x.ForumGroupId == o.Id).ToList()
            })
                .OrderBy(x => x.Id);
        }

        public ForumGroupEntity FindByUrl(string urlName)
        {
            return FindAll().FirstOrDefault(o => o.UrlName.ToLower() == urlName.ToLower());
        }
    }
}