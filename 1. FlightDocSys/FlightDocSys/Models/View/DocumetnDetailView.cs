using FlightDocSys.Models.Entities;

namespace FlightDocSys.Models.View
{
    public class DocumentDetailView
    {
        public string? DocumentId { get; set; } = Guid.NewGuid().ToString();    
        public string? Name { get; set;}
        public string? CategoryId { get; set; }
        public double Version { get; set; } = 1.0;
        public string? Note {  get; set; }
        public string? UserId { get; set; }
        public string? FlightId { get; set;}
        public DateTime UpdatedDate { get; set; }
        public string? FilePath { get; set; }
        public byte[]? FileData { get; set; }
        public FileType FileType { get; set; }
        public string? PreviousDocumentId { get; set; } = null;
    }
}
