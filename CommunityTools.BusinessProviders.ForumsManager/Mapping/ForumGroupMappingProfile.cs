using System;
using AutoMapper;
using CommunityTools.BusinessProvider.Models.Forums;

namespace CommunityTools.BusinessProviders.Forums.Mapping
{
    public class ForumGroupMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ForumGroup, Domain.Forums.ForumGroupEntity>()
                .ForMember(dest => dest.CreatedDateTime,
                    opt => opt.MapFrom(src => src.CreatedDateTime == DateTime.MinValue ? DateTime.UtcNow : src.CreatedDateTime));
            CreateMap<Domain.Forums.ForumGroupEntity, ForumGroup>();
        }
    }
}