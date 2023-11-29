using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace FlightDocSys.Models.Entity
{
    [Table("TYPE")]
    public class TYPE
    {
        [Key]
        public int TypeID { get; set; }
        public int Name { get; set; }
        [Timestamp]
        public DateTime CeateDate { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ICollection<USER> USER { get; set; }
       
    }
}
