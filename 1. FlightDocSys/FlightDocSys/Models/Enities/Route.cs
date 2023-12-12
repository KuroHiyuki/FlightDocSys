using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Entities
{
    [Table("ROUTE")]
    public partial class Route
    {
        public Route() { 
            Flights = new HashSet<Flight>();
        }
        [Key]
        public string RouteId { get; set; } = null!;
        public string PointOfloading { get; set; } = null!;
        public string PointOfunloading { get; set; } = null!;
        public decimal? Duration { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
