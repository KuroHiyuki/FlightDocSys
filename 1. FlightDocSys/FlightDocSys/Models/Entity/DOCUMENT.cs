
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Entity
{
    [Table("DOCUMENT")]
    public class DOCUMENT
    {
        [Key]
        public int DocumentID { get; set; }
        public int Name { get; set; }
        [Timestamp] 
        public DateTime CeateDate { get; set; }
        [MaxLength(2)]
        [DefaultValue(1.0)]
        public double Version { get; set; }
        public string FilePath { get; set; }
        public string Note { get; set; }
        public string FlightID { get; set; }
        [ForeignKey("FlightID")]
        public virtual ICollection<FLIGHT> FLIGHT { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ICollection<USER> USER { get; set; }
        public int TypeID { get; set; }
        [ForeignKey("TypeID")]
        public virtual ICollection<TYPE> TYPE { get; set; }


    }
}
