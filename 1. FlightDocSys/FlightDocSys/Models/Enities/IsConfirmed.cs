using FlightDocSys.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Enities
{
    [Table("IsConfirmed")]
    public class IsConfirmed
    {
        [Key]
        public string? DocumentId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Description { get; set; }
        public string? SnapshotSignature { get; set; }
        public virtual Document? Document { get; set; }
    }
}
