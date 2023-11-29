using FlightDocSys.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlightDocSys.Models.Relation
{
    [Table("GROUP_TYPE")]
    public class GROUP_TYPE
    {
        [Key]
        public int TypeID { get; set; }
        [ForeignKey("TypeID")]
        public virtual ICollection<TYPE> TYPE { get; set; }
        [Key]
        public int GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual ICollection<GROUP> GROUP { get; set; }

    }
}
