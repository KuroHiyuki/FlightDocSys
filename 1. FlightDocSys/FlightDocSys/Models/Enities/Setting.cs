using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Entities
{
    public enum Theme
    {
        Default = 0, Dark = 1,Light = 2
    }
    [Table("SETTING")] 
    public class Setting
    {
        public Theme Theme { get; set; }
        public string? Logo { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
