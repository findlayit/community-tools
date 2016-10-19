using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityTools.Domain.Surveys
{
    [Table("Question")]
    public class QuestionEntity : BaseEntity
    {
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public SurveyEntity Survey { get; set; }
        public int Idx { get; set; }
        public string QuestionText { get; set; }
        public int QuestionAnswerId { get; set; }
        [ForeignKey("QuestionAnswerId")]
        public QuestionAnswerEntity QuestionAnswer { get; set; }
    }
}