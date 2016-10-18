using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityTools.Domain.Forums
{
    [Table("ForumGroup")]
    public class ForumGroupEntity : BaseEntity
    {
         public string Title { get; set; }
        public string UrlName { get; set; }
        public virtual List<ForumEntity> Forums { get; set; } 
    }
}