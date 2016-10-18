using Autofac;
using CommunityTools.BusinessProviders.Users;
using CommunityTools.DataAccess.Common;
using CommunityTools.Services.Common;

namespace CommunityTools.Services.Users
{
    public class UserModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<UsersBusinessProviderModule>();
            builder.RegisterModule<ServiceCommonModule>();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();
        }
    }
}