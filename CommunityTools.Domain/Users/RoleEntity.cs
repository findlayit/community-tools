using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FlexProviders.Roles;
using Newtonsoft.Json;

namespace CommunityTools.Domain.Users
{
    [Table("Roles")]
    public class RoleEntity : BaseEntity, IFlexRole<UserEntity>
    {
        public RoleEntity()
        {
            Users = new List<UserEntity>();
        }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserEntity> Users { get; set; }
    }
}