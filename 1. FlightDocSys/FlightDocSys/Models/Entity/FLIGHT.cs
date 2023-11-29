using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Entity
{
    [Table("FLIGHT")]
    public class FLIGHT
    {
        [Key]
        public int FlightID { get; set; }
        public int Name { get; set; }
        [Timestamp]
        public DateTime DepartureDate { get; set; }
        public int RouteID { get; set; }
        [ForeignKey("RouteeID")]
        public virtual ICollection<ROUTE> ROUTE { get; set; }
    }
}
