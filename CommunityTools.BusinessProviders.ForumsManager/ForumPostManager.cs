using System.Collections.Generic;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Forums;
using CommunityTools.DataAccess.Forums;

namespace CommunityTools.BusinessProviders.Forums
{
    public class ForumPostManager : IForumPostManager
    {
        private readonly IMapper _mapper;
        private readonly IForumPostRepository _forumPostRepository;

        public ForumPostManager(IMapper mapper, IForumPostRepository forumPostRepository)
        {
            _mapper = mapper;
            _forumPostRepository = forumPostRepository;
        }
        public List<ForumPost> FindAll()
        {
            return _mapper.Map<List<ForumPost>>(_forumPostRepository.FindAll());
        }

        public ForumPost FindById(int id)
        {
            return _mapper.Map<ForumPost>(_forumPostRepository.FindById(id));
        }

        public void Add(ForumPost item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumPostEntity>(item);
            _forumPostRepository.Add(entity);
        }

        public void Update(ForumPost item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumPostEntity>(item);
            _forumPostRepository.Update(entity);
        }

        public void Remove(ForumPost item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumPostEntity>(item);
            _forumPostRepository.Remove(entity);
        }

        public void Delete(ForumPost item)
        {
            var entity = _mapper.Map<Domain.Forums.ForumPostEntity>(item);
            _forumPostRepository.Delete(entity);
        }

        public string FetchFullUrl(int id)
        {
            return _forumPostRepository.FetchFullUrl(id);
        }

        public List<ForumPost> FindByThreadUrl(string forumUrlName, string threadUrlName)
        {
            return _mapper.Map<List<ForumPost>>(_forumPostRepository.FindByThreadUrl(forumUrlName, threadUrlName));
        }
    }
}