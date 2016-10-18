using Autofac;
using CommunityTools.Common;

namespace CommunityTools.BusinessProvider.Common
{
    public class BusinessProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommonModule>();
        }
    }
}
