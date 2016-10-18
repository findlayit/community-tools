using System;

namespace CommunityTools.BusinessProvider.Common
{
    public interface IBaseModel
    {
        int Id { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDateTime { get; set; }
        bool IsDeleted { get; set; }
    }
}