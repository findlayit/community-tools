using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityTools.Domain.Surveys
{
    [Table("QuestionAnswer")]
    public class QuestionAnswerEntity : BaseEntity
    {
        public string Description { get; set; }
        public int AnswerType { get; set; }
    }
}