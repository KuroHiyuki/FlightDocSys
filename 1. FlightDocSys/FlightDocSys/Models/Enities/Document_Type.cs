using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Entities
{
    [Table("DOCUMENT_TYPE")]
    public partial class Document_Type
    {
        public Document_Type() 
        { 
            Documents = new HashSet<Document>();
            GroupDocumenttypes = new HashSet<GroupDocumenttype>();
        }  
        [Key]
        public int Document_TypeId { get; set; }
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<GroupDocumenttype> GroupDocumenttypes { get; set; }
        public virtual User? User { get; set; }
    }
}
