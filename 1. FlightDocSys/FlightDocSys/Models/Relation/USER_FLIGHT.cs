using FlightDocSys.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("USER_FLIGHT")]
    public class USER_FLIGHT
    {
        [Key]
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ICollection<USER> USER { get; set; }
        [Key]
        public int FlightID { get; set; }
        [ForeignKey("FlightID")]
        public virtual ICollection<FLIGHT> FLIGHT { get; set; }
    }
}
