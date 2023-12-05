using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Entities
{
    [Table("GROUP")]
    public partial class Group
    {
        public Group() 
        {
            GroupDocumenttypes = new HashSet<GroupDocumenttype>();
            GroupPermissions = new HashSet<GroupPermission>();
            UserGroups = new HashSet<UserGroup>();
        }
        [Key ]
        public int GroupId { get; set; }
        public string Name { get; set; } = null!;
        public string? Note { get; set; }
        public virtual ICollection<GroupDocumenttype> GroupDocumenttypes { get; set; }
        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
