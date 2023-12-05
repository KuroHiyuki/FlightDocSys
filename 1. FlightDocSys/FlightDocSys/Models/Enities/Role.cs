using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Entities
{
    [Table("ROLE")]
    public partial class Role
    {
        public Role() 
        { 
            Users = new HashSet<User>();
            RolePermissions = new HashSet<RolePermission>();
        }
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
      
    }
}
