using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityTools.Domain.Forums
{
    [Table("ForumPost")]
    public class ForumPostEntity: BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UrlName { get; set; }
        public int ForumThreadId { get; set; }
        [ForeignKey("ForumThreadId")]
        public ForumThreadEntity ForumThread { get; set; }

    }
}