namespace FlightDocSys.Models.View
{
    public class DocumentListView
    {
        public string DocumentName { get; set; } = null!;
        public string FlightName { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}
