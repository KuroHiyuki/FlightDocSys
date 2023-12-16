namespace FlightDocSys.Models.View
{
    public class FlightShortView
    {
        public string? FlightId { get; set; }
        public string? FlightName { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int SendFile { get; set; }
        public int ReturnFile { get; set; }
        public string? RouteId { get; set; }
    }
}
