using System.Collections.Generic;
using CommunityTools.BusinessProvider.Common;

namespace CommunityTools.BusinessProvider.Models.Forums
{
    public class ForumThread : BaseModel
    {
        public string Title { get; set; }
        public string UrlName { get; set; }
        public int ForumId { get; set; }
        public Forum Forum { get; set; }
        //public virtual List<ForumPost> ForumPosts { get; set; }
        public int PostCount { get; set; }
        public ForumPost FirstPost { get; set; }
        public ForumPost LastPost { get; set; }
    }
}