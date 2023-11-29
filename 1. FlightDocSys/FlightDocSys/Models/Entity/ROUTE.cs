using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Entity
{
    [Table("ROUTE")]
    public class ROUTE
    {
        [Key]
        public int RouteID { get; set; }
        public string PointOfLoading { get; set; }
        public string PointOfUnloading { get; set; }
        public int Duration { get; set; }
        
    }
}
