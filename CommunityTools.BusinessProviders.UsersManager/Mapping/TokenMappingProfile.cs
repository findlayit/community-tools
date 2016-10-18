using AutoMapper;
using CommunityTools.BusinessProvider.Models.Users;

namespace CommunityTools.BusinessProviders.Users.Mapping
{
    public class TokenMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Token, Domain.Users.TokenEntity>();
            CreateMap<Domain.Users.TokenEntity, Token>();
        }
    }
}