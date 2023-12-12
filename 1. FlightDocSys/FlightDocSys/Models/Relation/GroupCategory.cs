using FlightDocSys.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("GROUP_CATEGORY")]
    public class GroupCategory
    {
        public string? GroupId { get; set; }
        public string? CategoryId { get; set; }
        public virtual Group? Group { get; set;}
        public virtual Category? Category { get; set; }
    }
}
