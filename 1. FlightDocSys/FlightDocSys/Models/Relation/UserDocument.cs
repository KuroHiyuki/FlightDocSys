using FlightDocSys.Models.Entities;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("UserDocument")]
    public class UserDocument
    {
        public int UserId { get; set; }
        public int DocumentId { get; set; }
        public virtual User? User { get; set; }
        public virtual Document? Document { get; set; }    
    }
}
