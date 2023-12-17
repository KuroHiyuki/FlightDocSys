using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Entities
{
    [Table("CATEGORY")]
    public partial class Category
    {
        public Category() 
        { 
            Documents = new HashSet<Document>();
            GroupCategories = new HashSet<GroupCategory>();
        }  
        [Key]
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? UserId { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<GroupCategory> GroupCategories { get; set; }
        public virtual User? User { get; set; }
    }
}
