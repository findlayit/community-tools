using Autofac;
using CommunityTools.BusinessProviders.Forums;
using CommunityTools.DataAccess.Common;
using CommunityTools.Services.Common;

namespace CommunityTools.Services.Forums
{
    public class ForumModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ForumsBusinessProviderModule>();
            builder.RegisterModule<ServiceCommonModule>();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();
        }
    }
}