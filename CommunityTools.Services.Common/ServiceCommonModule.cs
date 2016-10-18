using Autofac;
using CommunityTools.Common;

namespace CommunityTools.Services.Common
{
    public class ServiceCommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommonModule>();
        }
    }
}