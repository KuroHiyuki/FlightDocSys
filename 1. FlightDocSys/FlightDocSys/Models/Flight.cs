using System;
using System.Collections.Generic;

namespace FlightDocSys.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Users = new HashSet<User>();
        }

        public int FlightId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public string RouteId { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
