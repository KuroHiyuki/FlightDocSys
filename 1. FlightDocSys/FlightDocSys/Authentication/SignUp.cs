using System.ComponentModel.DataAnnotations;

namespace FlightDocSys.Authentication
{
    public class SignUp
    {
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public int? NumberPhone { get; set; }
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
