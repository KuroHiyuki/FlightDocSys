using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Entities
{
    [Table("GROUP")]
    public partial class Group
    {
        public Group() 
        {
            GroupCategories = new HashSet<GroupCategory>();
            GroupPermissions = new HashSet<GroupPermission>();
            UserGroups = new HashSet<UserGroup>();
        }
        [Key ]
        public string? GroupId { get; set; }
        public string? GroupName { get; set; } = null!;
        public string? Note { get; set; }
        public virtual ICollection<GroupCategory> GroupCategories { get; set; }
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
