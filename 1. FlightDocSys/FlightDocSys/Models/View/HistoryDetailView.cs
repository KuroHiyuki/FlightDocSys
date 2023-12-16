namespace FlightDocSys.Models.View
{
    public class HistoryDetailView
    {
        public string? HistoryId { get; set; }
        public string? HistoryName { get; set; }
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public double Version { get; set; } = 1.0;
        public string? Note { get; set; }
        public string? UserId { get; set; }
        public string? FlightId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Filepath { get; set; }
        public string? FileType { get; set; }
    }
}
