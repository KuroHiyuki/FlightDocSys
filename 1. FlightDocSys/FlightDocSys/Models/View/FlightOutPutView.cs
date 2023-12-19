namespace FlightDocSys.Models.View
{
    public class FlightOutPutView
    {
        public string? FlightId { get; set; } = Guid.NewGuid().ToString();
        public string? FlightName { get; set; }
        public DateTime DepartureDate { get; set; }
        public int TotalFile { get; set; }
        public string? RouteId { get; set; }
        public string? PoL { get; set; }
        public string? PoU { get; set; }
    }
}
