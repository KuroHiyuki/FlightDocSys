using FlightDocSys.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("GroupDocumenttype")]
    public class GroupDocumenttype
    {
       
        public int Document_TypeId { get; set; }
        public int GroupId { get; set; }
        public virtual Group? Group { get; set;}
        public virtual Document_Type? Document_Type { get; set; }
    }
}
