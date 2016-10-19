using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityTools.Domain.Surveys
{
    [Table("QuestionAnswerOption")]
    public class QuestionAnswerOptionEntity : BaseEntity
    {
        public int QuestionAnswerId { get; set; }
        [ForeignKey("QuestionAnswerId")]
        public QuestionAnswerEntity QuestionAnswer { get; set; }
        public int Idx { get; set; }
        public string OptionText { get; set; }
        public int OptionValue { get; set; }
    }
}