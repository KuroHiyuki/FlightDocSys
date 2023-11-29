using System;
using System.Collections.Generic;

namespace FlightDocSys.Models
{
    public partial class GroupPermission
    {
        public int GroupId { get; set; }
        public int PermissionId { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Group Group { get; set; } = null!;
        public virtual Permission Permission { get; set; } = null!;
    }
}
