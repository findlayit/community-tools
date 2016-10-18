using System;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Forums;

namespace CommunityTools.BusinessProviders.Forums.Mapping
{
    public class ForumMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Forum, Domain.Forums.ForumEntity>()
                .ForMember(dest => dest.CreatedDateTime,
                    opt => opt.MapFrom(src => src.CreatedDateTime == DateTime.MinValue ? DateTime.UtcNow : src.CreatedDateTime));
            CreateMap<Domain.Forums.ForumEntity, Forum>();
        }
    }
}