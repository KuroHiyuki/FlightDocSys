using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Entities
{
    [Table("DOCUMENT")]
    public partial class Document
    {
        public Document() 
        {
            UserDocuments = new HashSet<UserDocument>();
        }

        [Key]
        public int DocumentId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public decimal Version { get; set; }
        public string Filepath { get; set; } = null!;
        public string? Note { get; set; }
        public int FlightId { get; set; }
        public int Document_TypeId { get; set; }
        public virtual Flight? Flight { get; set; }
        public virtual Document_Type? Document_Type { get; set; }
        public virtual ICollection<UserDocument> UserDocuments { get; set; }
    }
}
