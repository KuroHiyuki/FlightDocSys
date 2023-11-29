using System;
using System.Collections.Generic;

namespace FlightDocSys.Models
{
    public partial class Route
    {
        public string RouteId { get; set; } = null!;
        public string PointOfloading { get; set; } = null!;
        public string PointOfunloading { get; set; } = null!;
        public short? Duration { get; set; }
    }
}
