using System;
using System.Collections.Generic;

namespace FlightDocSys.Models
{
    public partial class User
    {
        public User()
        {
            UserGroups = new HashSet<UserGroup>();
            Documents = new HashSet<Document>();
            Flights = new HashSet<Flight>();
        }

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public int? NumberPhone { get; set; }
        public bool StatusCode { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<UserGroup> UserGroups { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
