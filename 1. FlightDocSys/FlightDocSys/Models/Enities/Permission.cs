using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Entities
{
    [Table("PERMISSION")]
    public partial class Permission
    {
        public Permission() 
        {
            GroupPermissions = new HashSet<GroupPermission>();
            RolePermissions = new HashSet<RolePermission>();
        }
        [Key]
        public int PermissionId { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
