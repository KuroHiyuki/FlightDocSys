using FlightDocSys.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models
{
    [Table("USER_GROUP")]
    public partial class UserGroup
    {
        public string? UserId { get; set; }
        public string? GroupId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsCreated { get; set; } = true;
        public bool IsMember { get; set; } = true;
        public virtual User? User { get; set; }
        public virtual Group? Group { get; set; }
    }
}
