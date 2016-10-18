using System;
using System.Collections.Generic;
using AutoMapper;
using CommunityTools.BusinessProvider.Common;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.DataAccess.Forums;

namespace CommunityTools.BusinessProviders.Forums
{
    public class ForumThreadManager : IForumThreadManager
    {
        private readonly IMapper _mapper;
        private readonly IForumThreadRepository _forumThreadRepository;

        public ForumThreadManager(IMapper mapper, IForumThreadRepository forumThreadRepository)
        {
            _mapper = mapper;
            _forumThreadRepository = forumThreadRepository;
        }
        public List<ForumThread> FindAll()
        {
            return _mapper.Map<List<ForumThread>>(_forumThreadRepository.FindAll());
        }
        public List<ForumThread> FindByForumId(int forumId)
        {
            return _mapper.Map<List<ForumThread>>(_forumThreadRepository.FindByForumId(forumId));
        }
        public List<ForumThread> FindByForumUrl(string urlName)
        {
            return _mapper.Map<List<ForumThread>>(_forumThreadRepository.FindByForumUrl(urlName));
        }

        public ForumThread FindById(int id)
        {
            return _mapper.Map<ForumThread>(_forumThreadRepository.FindById(id));
        }
        public ForumThread FindByUrl(string forumUrlName,string urlName)
        {
            return _mapper.Map<ForumThread>(_forumThreadRepository.FindByUrl(forumUrlName, urlName));
        }

        public void Add(ForumThread item)
        {
            item.UrlName = UrlHelpers.ConvertToUrl(item.Title);
            item.CreatedDateTime = DateTime.UtcNow;
            item.CreatedBy = 1;
            var entity = _mapper.Map<Domain.Forums.ForumThreadEntity>(item);
            _forumThreadRepository.Add(entity);
        }

        public void Update(ForumThread item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumThreadEntity>(item);
            _forumThreadRepository.Update(entity);
        }

        public void Remove(ForumThread item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumThreadEntity>(item);
            _forumThreadRepository.Remove(entity);
        }

        public void Delete(ForumThread item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumThreadEntity>(item);
            _forumThreadRepository.Delete(entity);
        }


    }
}