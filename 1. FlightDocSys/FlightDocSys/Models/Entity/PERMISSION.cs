using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Entity
{
    [Table("PERMISSION")]
    public class PERMISSION
    {
        [Key]
        public int PermissionID { get; set; }
        public int Name { get; set; }
    }
}
