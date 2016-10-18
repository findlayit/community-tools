using System;

namespace CommunityTools.Domain
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDateTime { get; set; }
        bool IsDeleted { get; set; }
    }
}