using System.Data.Entity;
using CommunityTools.Domain.Forums;

namespace CommunityTools.DataAccess.Forums
{
    public class ForumsContext : DbContext
    {
        public ForumsContext() : base("ForumsContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<ForumsContext>(null);
        }

        // DbSets
        public DbSet<ForumGroupEntity> ForumGroups { get; set; }
        public DbSet<ForumEntity> Forums { get; set; }
        public DbSet<ForumThreadEntity> ForumThreads { get; set; }
        public DbSet<ForumPostEntity> ForumPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}