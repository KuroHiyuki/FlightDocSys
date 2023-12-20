namespace FlightDocSys.Models.View
{
    public class DocumentUpdateView_2
    {
        public string? Name { get; set; }
        public string? Note { get; set; }
        public string? FlightId { get; set; }
        public string? CategoryId { get; set; }
        public string? UserId { get; set; }
        public string? PreviousDocumentId { get; set; } = null;
    }
}
