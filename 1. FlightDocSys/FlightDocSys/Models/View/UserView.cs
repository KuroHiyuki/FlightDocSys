using System.ComponentModel.DataAnnotations;

namespace FlightDocSys.Models.View
{
    public class UserView
    {
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsActived { get; set; } = true;
    }
}
