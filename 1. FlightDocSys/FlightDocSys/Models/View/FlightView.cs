namespace FlightDocSys.Models.View
{
    public class FlightView
    {
        public string FlightName { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int SendFile {  get; set; }
        public int ReturnFile { get; set; }
    }
}
