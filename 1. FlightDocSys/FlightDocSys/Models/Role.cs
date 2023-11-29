using System;
using System.Collections.Generic;

namespace FlightDocSys.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
            Permissions = new HashSet<Permission>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
