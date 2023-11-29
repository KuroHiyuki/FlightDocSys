using System;
using System.Collections.Generic;

namespace FlightDocSys.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupPermissions = new HashSet<GroupPermission>();
            UserGroups = new HashSet<UserGroup>();
            Documents = new HashSet<Document>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; } = null!;
        public string? Note { get; set; }

        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
