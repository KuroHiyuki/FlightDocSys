using System;
using System.Collections.Generic;

namespace FlightDocSys.Models
{ 
    public partial class Permission
    {
        public Permission()
        {
            GroupPermissions = new HashSet<GroupPermission>();
            Roles = new HashSet<Role>();
        }

        public int PermissionId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
