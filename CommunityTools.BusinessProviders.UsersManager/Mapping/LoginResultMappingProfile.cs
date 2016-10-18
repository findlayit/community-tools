using AutoMapper;
using CommunityTools.BusinessProvider.Models.Users;

namespace CommunityTools.BusinessProviders.Users.Mapping
{
    public class LoginResultMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<LoginResult, Domain.Users.LoginResult>();
            CreateMap<Domain.Users.LoginResult, LoginResult>();
        }

    }
}