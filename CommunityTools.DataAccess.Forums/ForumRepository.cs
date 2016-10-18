using System.Collections.Generic;
using System.Linq;
using CommunityTools.DataAccess.Common;
using CommunityTools.Domain.Forums;
using System.Data.Entity;

namespace CommunityTools.DataAccess.Forums
{
    public class ForumRepository : BaseRepository<ForumEntity>, IForumRepository
    {
        public ForumRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override IEnumerable<ForumEntity> FindAll()
        {
            var entities = _unitOfWork.Set<ForumEntity>().Include(o => o.ForumGroup);
            var threads = _unitOfWork.Set<ForumThreadEntity>();
            return entities.Select(o => new ForumEntity()
            {
                Title = o.Title,
                UrlName =  o.UrlName,
                Description = o.Description,
                ForumGroupId = o.ForumGroupId,
                ForumGroup = o.ForumGroup,
                ThreadCount = threads.Count(t => t.ForumId == o.Id)
            })
            .OrderBy(o => o.Id)
            .ToList();
        }
        public ForumEntity FindByUrl(string urlName)
        {
            return _unitOfWork.Set<ForumEntity>()
                .FirstOrDefault(o => o.UrlName.ToLower() == urlName.ToLower());
        }
    }
}