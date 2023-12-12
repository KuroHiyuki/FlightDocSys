using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Relation;
using Microsoft.AspNetCore.Identity;

namespace FlightDocSys.Models.Entities
{
    [Table("USER")]
    public partial class User: IdentityUser
    {
        public User() 
        {
            UserFlights = new HashSet<UserFlight>();
            UserGroups = new HashSet<UserGroup>();
            Categories  = new HashSet<Category>();
            Documents = new HashSet<Document>();
        }
        public string? Name { get; set; }
        [Required,EmailAddress]
        public bool IsAdmin { get; set; } = false;
        public bool IsActived { get; set; } = true;
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<UserFlight>? UserFlights { get; set; }
        public virtual ICollection<UserGroup>? UserGroups { get; set; }
        public virtual Setting? Setting { get; set; }
        public virtual ICollection<Document>? Documents { get; set; }
    }
}
