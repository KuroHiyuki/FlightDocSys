using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocSys.Models.Entities
{
    public enum FileLogo
    {
        PNG = 1,
        JPEG = 2,
    }
    public enum Theme
    {
        Default = 0, Dark = 1,Light = 2
    }
    [Table("SETTING")] 
    public class Setting
    {
        public Theme Theme { get; set; }
        public string? NameLogo { get; set; }
        public byte[]? Data { get; set; }
        public string? FilePath { get; set; }
        public FileLogo fileLogo { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
