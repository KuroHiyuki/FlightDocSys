using FlightDocSys.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("UserFlight")]
    public class UserFlight
    {
        public int UserId { get; set; }
        public int FlightId { get; set; }
        public virtual Flight? Flight { get; set;}
        public virtual User? User { get; set; }
    }
}
