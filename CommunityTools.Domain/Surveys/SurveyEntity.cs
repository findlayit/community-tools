using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace CommunityTools.Domain.Surveys
{
    [Table("Survey")]
    public class SurveyEntity : BaseEntity
    {
        public string Title { get; set; }
        public string UrlName { get; set; }
        public string Description { get; set; }
    }
}