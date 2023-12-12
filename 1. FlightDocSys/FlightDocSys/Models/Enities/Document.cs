using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Enities;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Entities
{
    [Table("DOCUMENT")]
    public partial class Document
    {
        public Document() 
        {
            Histories = new HashSet<History>();
        }

        [Key]
        public string? DocumentId { get; set; }
        public string? Name { get; set; }
        public DateTime UpdatedDate { get; set; }
        public decimal Version { get; set; }
        public string? Filepath { get; set; }
        public string? FileType { get; set; }
        public string? Note { get; set; }
        public string? FlightId { get; set; }
        public string? CategoryId { get; set; }
        public string? UserId { get; set; }
        public virtual Flight? Flight { get; set; }
        public virtual Category? Category { get; set; }
        public virtual User? User { get; set; }
        public virtual IsConfirmed? IsConfirmed { get; set; }
        public virtual ICollection<History> Histories { get; set; }

    }
}
