using Autofac;
using CommunityTools.Common;

namespace CommunityTools.DataAccess.Common
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommonModule>();
        }

    }
}
