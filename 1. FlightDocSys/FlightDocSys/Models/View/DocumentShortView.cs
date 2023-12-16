namespace FlightDocSys.Models.View
{
    public class DocumentShortView
    {
        public string? DocumentId { get; set; }
        public string? DocumentName { get; set; }
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? FlightId { get; set; }
        public string? FlightName { get; set; }
        public DateTime DepartureDate { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
