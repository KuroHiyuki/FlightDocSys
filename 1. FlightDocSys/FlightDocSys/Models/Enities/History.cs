using FlightDocSys.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FlightDocSys.Models.Enities
{
    [Table("HISTORY")]
    public class History
    {
        [Key]
        public string? HistoryId { get; set; }
        public string? Name { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal Version { get; set; }
        public string? Filepath { get; set; }
        public string? FileType { get; set; }
        public string? Note { get; set; }
        public string? DocumentId { get; set; }    
        public Document? Document { get; set; }
    }
}
