using System.Collections.Generic;
using System.Text.RegularExpressions;
using AutoMapper;
using CommunityTools.BusinessProvider.Common;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.DataAccess.Forums;

namespace CommunityTools.BusinessProviders.Forums
{
    public class ForumGroupManager : IForumGroupManager
    {
        private readonly IMapper _mapper;
        private readonly IForumGroupRepository _forumGroupRepository;

        public ForumGroupManager(IMapper mapper, IForumGroupRepository forumGroupRepository)
        {
            _mapper = mapper;
            _forumGroupRepository = forumGroupRepository;
        }
        public List<ForumGroup> FindAll()
        {
            return _mapper.Map<List<ForumGroup>>(_forumGroupRepository.FindAll());
        }

        public ForumGroup FindById(int id)
        {
            return _mapper.Map<ForumGroup>(_forumGroupRepository.FindById(id));
        }
        public ForumGroup FindByUrl(string urlName)
        {
            return _mapper.Map<ForumGroup>(_forumGroupRepository.FindByUrl(urlName));
        }

        public void Add(ForumGroup item)
        {
            item.UrlName = UrlHelpers.ConvertToUrl(item.Title);
            var entity = _mapper.Map<Domain.Forums.ForumGroupEntity>(item);
            _forumGroupRepository.Add(entity);
        }

        public void Update(ForumGroup item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumGroupEntity>(item);
            _forumGroupRepository.Update(entity);
        }

        public void Remove(ForumGroup item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumGroupEntity>(item);
            _forumGroupRepository.Remove(entity);
        }

        public void Delete(ForumGroup item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumGroupEntity>(item);
            _forumGroupRepository.Delete(entity);
        }
    }
}