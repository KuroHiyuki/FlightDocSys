using FlightDocSys.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models
{
    [Table("UserGroup")]
    public partial class UserGroup
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual User? User { get; set; }
        public virtual Group? Group { get; set; }

    }
}
