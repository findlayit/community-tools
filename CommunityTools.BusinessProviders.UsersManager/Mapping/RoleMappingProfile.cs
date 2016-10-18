using AutoMapper;
using CommunityTools.BusinessProvider.Models.Users;

namespace CommunityTools.BusinessProviders.Users.Mapping
{
    public class RoleMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Role, Domain.Users.RoleEntity>();
            CreateMap<Domain.Users.RoleEntity, Role>();
        }
    }
}