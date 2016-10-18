using System;
using System.Linq;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Forums;

namespace CommunityTools.BusinessProviders.Forums.Mapping
{
    public class ForumThreadMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ForumThread, Domain.Forums.ForumThreadEntity>()
                .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime == DateTime.MinValue ? DateTime.UtcNow : src.CreatedDateTime));
            CreateMap<Domain.Forums.ForumThreadEntity, ForumThread>()
                .ForMember(dest => dest.PostCount, opt => opt.MapFrom(src => src.ForumPosts.Count))
                .ForMember(dest => dest.FirstPost, opt => opt.MapFrom(src => src.ForumPosts.OrderBy(p => p.CreatedDateTime).FirstOrDefault()))
                .ForMember(dest => dest.LastPost, opt => opt.MapFrom(src => src.ForumPosts.OrderByDescending(p => p.CreatedDateTime).FirstOrDefault()));
        }
    }
}