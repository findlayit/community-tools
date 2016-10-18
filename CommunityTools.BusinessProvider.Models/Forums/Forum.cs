using CommunityTools.BusinessProvider.Common;

namespace CommunityTools.BusinessProvider.Models.Forums
{
    public class Forum : BaseModel
    {
        public string Title { get; set; }
        public string UrlName { get; set; }
        public string Description { get; set; }
        public int ForumGroupId { get; set; }
        public int ThreadCount { get; set; }
        public int PostCount { get; set; }
        public ForumPost LastPost { get; set; }
    }
}