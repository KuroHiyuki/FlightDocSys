using FlightDocSys.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("USER_FLIGHT")]
    public class UserFlight
    {
        public string? UserId { get; set; }
        public string? FlightId { get; set; }
        public virtual Flight? Flight { get; set;}
        public virtual User? User { get; set; }
    }
}
