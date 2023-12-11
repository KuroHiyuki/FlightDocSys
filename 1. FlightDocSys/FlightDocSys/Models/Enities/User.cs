using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Entities
{
    [Table("USER")]
    public partial class User
    {
        public User() 
        {
            UserFlights = new HashSet<UserFlight>();
            UserGroups = new HashSet<UserGroup>();
            UserDocuments = new HashSet<UserDocument>();
        }
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public int? NumberPhone { get; set; }
        public bool StatusCode { get; set; }
        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Document_Type>? Document_Types { get; set; }
        public virtual ICollection<UserDocument>? UserDocuments { get; set; }
        public virtual ICollection<UserFlight>? UserFlights { get; set; }
        public virtual ICollection<UserGroup>? UserGroups { get; set; }
        public virtual Setting Setting { get; set; } = null!;
    }
}
