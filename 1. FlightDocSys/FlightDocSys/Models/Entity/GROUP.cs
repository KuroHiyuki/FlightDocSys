
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Entity
{
    [Table("GROUP")]
    public class GROUP
    {
        [Key]
        public int GrouptID { get; set; }
        public int Name { get; set; }
        public string Note { get; set; }
    }
}
