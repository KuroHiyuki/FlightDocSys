using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Entity
{
    [Table("ROLE")]
    public class ROLE
    {
        [Key]
        public int RoleID { get; set; }
        public string Name { get; set; }

    }
}
