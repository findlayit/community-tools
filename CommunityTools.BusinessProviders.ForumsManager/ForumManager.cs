using System;
using System.Collections.Generic;
using AutoMapper;
using CommunityTools.BusinessProvider.Common;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.DataAccess.Forums;

namespace CommunityTools.BusinessProviders.Forums
{
    public class ForumManager : IForumManager
    {
        private readonly IMapper _mapper;
        private readonly IForumRepository _forumRepository;

        public ForumManager(IMapper mapper, IForumRepository forumRepository)
        {
            _mapper = mapper;
            _forumRepository = forumRepository;
        }
        public List<Forum> FindAll()
        {
            return _mapper.Map<List<Forum>>(_forumRepository.FindAll());
        }

        public Forum FindById(int id)
        {
            return _mapper.Map<Forum>(_forumRepository.FindById(id));
        }
        public Forum FindByUrl(string urlName)
        {
            return _mapper.Map<Forum>(_forumRepository.FindByUrl(urlName));
        }

        public void Add(Forum item)
        {
            item.UrlName = UrlHelpers.ConvertToUrl(item.Title);
            item.CreatedDateTime = DateTime.UtcNow;
            item.CreatedBy = 1;
            var entity = _mapper.Map<Domain.Forums.ForumEntity>(item);
            _forumRepository.Add(entity);
        }

        public void Update(Forum item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumEntity>(item);
            _forumRepository.Update(entity);
        }

        public void Remove(Forum item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumEntity>(item);
            _forumRepository.Remove(entity);
        }

        public void Delete(Forum item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumEntity>(item);
            _forumRepository.Delete(entity);
        }

    }
}