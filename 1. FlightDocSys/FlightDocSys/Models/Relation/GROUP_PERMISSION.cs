using FlightDocSys.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("GROUP_PERMISSION")]
    public class GROUP_PERMISSION
    {
        [Key]
        public int PermissionID { get; set; }
        [ForeignKey("PermissionID")]
        public virtual ICollection<PERMISSION> TYPE { get; set; }
        [Key]
        public int GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual ICollection<GROUP> GROUP { get; set; }
        [Timestamp]
        public DateTime CeateDate { get; set; }
    }
}
