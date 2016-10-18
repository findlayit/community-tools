using Autofac;
using CommunityTools.Proxy.Common;
using CommunityTools.Services.Common;

namespace CommunityTools.Proxy
{
    public class ProxyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceCommonModule>();
            builder.RegisterModule<ProxyCommonModule>();
        }
    }
}