using FlightDocSys.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("USER_GROUP")]
    public class USER_GROUP
    {
        [Key]
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ICollection<USER> USER { get; set; }
        [Key]
        public int GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual ICollection<GROUP> GROUP { get; set; }
        [Timestamp]
        public DateTime CeateDate { get; set; }
    }
}
