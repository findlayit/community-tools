using System.Data.Entity;
using Autofac;
using CommunityTools.DataAccess.Common;

namespace CommunityTools.DataAccess.Surveys
{
    public class SurveysDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Common Data Access Module
            builder.RegisterModule<DataAccessModule>();
            // Repositories for this module
            builder.RegisterType<SurveyRepository>().As<ISurveyRepository>();
            builder.RegisterType<QuestionRepository>().As<IQuestionRepository>();
            builder.RegisterType<QuestionAnswerRepository>().As<IQuestionAnswerRepository>();
            builder.RegisterType<QuestionAnswerOptionRepository>().As<IQuestionAnswerOptionRepository>();
            // The DbContext
            builder.RegisterType<SurveysContext>().As<DbContext>();
        }
    }
}