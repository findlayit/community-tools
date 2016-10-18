using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace CommunityTools.Domain.Forums
{
    [Table("Forum")]
    public class ForumEntity : BaseEntity
    {
        public string Title { get; set; }
        public string UrlName { get; set; }
        public string Description { get; set; }
        public int ForumGroupId { get; set; }

        [ForeignKey("ForumGroupId")]
        public ForumGroupEntity ForumGroup { get; set; }

        public virtual List<ForumThreadEntity> ForumThreads { get; set; }

        [NotMapped]
        public int ThreadCount { get; set; }
        [NotMapped]
        public int PostCount { get; set; }
        [NotMapped]
        public ForumPostEntity LastPost { get; set; }
    }
}