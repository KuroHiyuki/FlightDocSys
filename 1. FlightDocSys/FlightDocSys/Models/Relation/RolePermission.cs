using FlightDocSys.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("RolePermission")]
    public class RolePermission
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public virtual Permission? Permission { get; set; }
        public virtual Role? Role { get; set;}
    }
}
