using System.Data.Entity;
using CommunityTools.Domain.Surveys;

namespace CommunityTools.DataAccess.Surveys
{
    public class SurveysContext : DbContext
    {
        public SurveysContext() : base("SurveysContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<SurveysContext>(null);
        }

        // DbSets
        public DbSet<SurveyEntity> Surveys { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<QuestionAnswerEntity> QuestionAnswers { get; set; }
        public DbSet<QuestionAnswerOptionEntity> QuestionAnswerOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
