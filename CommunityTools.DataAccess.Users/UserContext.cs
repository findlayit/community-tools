using System.Data.Entity;
using CommunityTools.Domain.Users;

namespace CommunityTools.DataAccess.Users
{
    public class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<UserContext>(null);
        }

        // DbSets
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                   .HasMany<RoleEntity>(s => s.Roles)
                   .WithMany(c => c.Users)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("UserId");
                       cs.MapRightKey("RoleId");
                       cs.ToTable("UserRoles");
                   });
        }

    }
}