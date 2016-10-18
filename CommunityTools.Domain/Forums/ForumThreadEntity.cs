using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CommunityTools.Domain.Forums
{
    [Table("ForumThread")]
    public class ForumThreadEntity : BaseEntity
    {
        public string Title { get; set; }
        public string UrlName { get; set; }
        public int ForumId { get; set; }
        [ForeignKey("ForumId")]
        public ForumEntity Forum { get; set; }
        public virtual List<ForumPostEntity> ForumPosts { get; set; }
    }
}