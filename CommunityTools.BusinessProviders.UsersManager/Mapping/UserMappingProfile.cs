using AutoMapper;
using CommunityTools.BusinessProvider.Models.Users;

namespace CommunityTools.BusinessProviders.Users.Mapping
{
    public class UserMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<User, Domain.Users.UserEntity>();
            CreateMap<Domain.Users.UserEntity, User>();
        }
    }
}