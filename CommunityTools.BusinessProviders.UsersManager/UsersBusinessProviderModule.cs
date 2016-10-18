using Autofac;
using CommunityTools.BusinessProvider.Common;
using CommunityTools.DataAccess.Users;

namespace CommunityTools.BusinessProviders.Users
{
    public class UsersBusinessProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<UsersDataAccessModule>();
            builder.RegisterModule<BusinessProviderModule>();

            builder.RegisterType<UserManager>().As<IUserManager>();
            //builder.Register(c => new UserManager(c.Resolve<IUserRepository>(), c.Resolve<ITokenRepository>(), c.Resolve<IRoleRepository>())).As(typeof(IUserManager));
        }

    }
}
