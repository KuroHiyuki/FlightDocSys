using FlightDocSys.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("GroupPermission")]
    public partial class GroupPermission
    {
        public int GroupId { get; set; }
        public int PermissionId { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual Group? Group { get; set; }
        public virtual Permission? Permission { get; set;}
    }
}
