using FlightDocSys.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("USER_DOCUMENT")]
    public class USER_DOCUMENT
    {
        [Key]
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ICollection<USER> USER { get; set; }
        [Key]
        public int DocumentpID { get; set; }
        [ForeignKey("DocumentID")]
        public virtual ICollection<DOCUMENT> DOCUMENT { get; set; }
    }
}
