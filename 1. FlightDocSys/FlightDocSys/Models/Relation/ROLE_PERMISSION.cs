using FlightDocSys.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightDocSys.Models.Relation
{
    [Table("ROLE_PERMISSION")]
    public class ROLE_PERMISSION
    {
        [Key]
        public int PermissionID { get; set; }
        [ForeignKey("PermissionID")]
        public virtual ICollection<PERMISSION> TYPE { get; set; }
        [Key]
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual ICollection<ROLE> ROLE { get; set; }
  
    }
}
