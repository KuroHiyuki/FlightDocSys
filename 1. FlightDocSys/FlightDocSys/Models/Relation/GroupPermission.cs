using FlightDocSys.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Relation
{
    [Table("GROUP_PERMISSION")]
    public partial class GroupPermission
    {
        public string? GroupId { get; set; }
        public string? PermissionId { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual Group? Group { get; set; }
        public virtual Permission? Permission { get; set;}
    }
}
