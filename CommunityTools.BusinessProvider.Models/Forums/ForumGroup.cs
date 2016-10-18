using System.Collections.Generic;
using CommunityTools.BusinessProvider.Common;

namespace CommunityTools.BusinessProvider.Models.Forums
{
    public class ForumGroup : BaseModel
    {
         public string Title { get; set; }
        public string UrlName { get; set; }
        public virtual List<Forum> Forums { get; set; }
    }
}