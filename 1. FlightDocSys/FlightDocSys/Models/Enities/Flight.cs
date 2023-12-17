using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Entities
{
    [Table("FLIGHT")]
    public partial class Flight
    {
        public Flight()
        {
            Documents = new HashSet<Document>();
            UserFlights = new HashSet<UserFlight>();
        }

        [Key]
        public string? FlightId { get; set; }
        public string? FlightName { get; set; } 
        public DateTime DeparturedDate { get; set; }
        public string? RouteId { get; set; } 
        public virtual Route? Route { get; set; }
        public virtual ICollection<Document>? Documents { get; set; }
        public virtual ICollection<UserFlight>? UserFlights { get; set; }

    }
}
