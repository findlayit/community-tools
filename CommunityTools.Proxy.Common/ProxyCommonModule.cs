using Autofac;
using CommunityTools.Common;

namespace CommunityTools.Proxy.Common
{
    public class ProxyCommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommonModule>();
        }
    }
}
