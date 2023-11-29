using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Entity
{
    [Table("USER")]
    public class USER
    {
        [Key]
        public int UserID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public int UserNumber { get; set; }
        [Timestamp]
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleId")]
        public virtual ICollection<ROLE> Role { get; set; }

    }
}
