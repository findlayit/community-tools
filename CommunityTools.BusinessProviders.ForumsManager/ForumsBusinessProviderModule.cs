using Autofac;
using CommunityTools.BusinessProvider.Common;
using CommunityTools.DataAccess.Forums;

namespace CommunityTools.BusinessProviders.Forums
{
    public class ForumsBusinessProviderModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ForumsDataAccessModule>();
            builder.RegisterModule<BusinessProviderModule>();

            builder.RegisterType<ForumGroupManager>().As<IForumGroupManager>();
            builder.RegisterType<ForumManager>().As<IForumManager>();
            builder.RegisterType<ForumThreadManager>().As<IForumThreadManager>();
            builder.RegisterType<ForumPostManager>().As<IForumPostManager>();
        }
    }
}
