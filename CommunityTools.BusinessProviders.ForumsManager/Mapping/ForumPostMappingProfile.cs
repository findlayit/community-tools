using System;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Forums;

namespace CommunityTools.BusinessProviders.Forums.Mapping
{
    public class ForumPostMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ForumPost, Domain.Forums.ForumPostEntity>()
                .ForMember(dest => dest.ForumThreadId,
                    opt => opt.MapFrom(src => src.ForumThreadId == 0 ? null : (int?) src.ForumThreadId))
                .ForMember(dest => dest.CreatedDateTime,
                    opt => opt.MapFrom(src => src.CreatedDateTime == DateTime.MinValue ? DateTime.UtcNow : src.CreatedDateTime));
            CreateMap<Domain.Forums.ForumPostEntity, ForumPost>();
        }
    }
}