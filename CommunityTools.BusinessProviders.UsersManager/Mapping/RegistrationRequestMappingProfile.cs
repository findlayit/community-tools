using AutoMapper;
using CommunityTools.BusinessProvider.Models.Users;

namespace CommunityTools.BusinessProviders.Users.Mapping
{
    public class RegistrationRequestMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<RegistrationRequest, Domain.Users.RegistrationRequest>();
            CreateMap<Domain.Users.RegistrationRequest, RegistrationRequest>();
        }
    }
}