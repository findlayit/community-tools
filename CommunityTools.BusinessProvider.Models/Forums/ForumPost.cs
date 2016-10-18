using CommunityTools.BusinessProvider.Common;

namespace CommunityTools.BusinessProvider.Models.Forums
{
    public class ForumPost : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UrlName { get; set; }
        public int ForumThreadId { get; set; }
    }
}