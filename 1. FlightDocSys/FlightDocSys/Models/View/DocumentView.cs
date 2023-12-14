namespace FlightDocSys.Models.View
{
    public class DocumentView
    {
        public string? DocumentName { get; set; }
        public string? CategoryName { get; set; }
        public string? FlightName { get; set; }
        public DateTime DepartureDate { get; set; }
        public string? UserName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
