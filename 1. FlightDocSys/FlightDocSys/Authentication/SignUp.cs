using System.ComponentModel.DataAnnotations;

namespace FlightDocSys.Authentication
{
    public class SignUp
    {
        [Required]
        public string? Name { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; } 
        [Required]
        public string? NumberPhone { get; set; }
        [Required]
        public string? Password { get; set; } 
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
