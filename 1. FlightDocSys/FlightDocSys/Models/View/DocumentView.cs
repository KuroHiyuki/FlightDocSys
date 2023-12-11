namespace FlightDocSys.Models.View
{
    public class DocumentView
    {
        public string DocumentName { get; set; } = null!;
        public string? DocumentTypeName { get; set; }
        public string FlightName { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}
