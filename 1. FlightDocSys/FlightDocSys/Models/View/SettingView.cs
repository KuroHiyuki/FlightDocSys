using FlightDocSys.Models.Entities;

namespace FlightDocSys.Models.View
{
    public class SettingView
    {
        public Theme Theme { get; set; }
        public string? NameLogo { get; set; }
        public string? FilePath { get; set; }
        public FileLogo fileLogo { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UserId { get; set; }
    }
}
