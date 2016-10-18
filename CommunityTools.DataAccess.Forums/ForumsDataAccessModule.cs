using System.Data.Entity;
using Autofac;
using CommunityTools.DataAccess.Common;

namespace CommunityTools.DataAccess.Forums
{
    public class ForumsDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Common Data Access Module
            builder.RegisterModule<DataAccessModule>();
            // Repositories for this module
            builder.RegisterType<ForumGroupRepository>().As<IForumGroupRepository>();
            builder.RegisterType<ForumRepository>().As<IForumRepository>();
            builder.RegisterType<ForumThreadRepository>().As<IForumThreadRepository>();
            builder.RegisterType<ForumPostRepository>().As<IForumPostRepository>();
            // The DbContext
            builder.RegisterType<ForumsContext>().As<DbContext>();
        }
    }
}
