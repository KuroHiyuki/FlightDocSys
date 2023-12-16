namespace FlightDocSys.Models.View
{
    public class GroupShortView
    {
        public string? GroupId { get; set; }
        public string? GroupName { get; set;}
        public string? UserId { get; set; }
        public string? UserEmail { get; set;}
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? Note {  get; set; }
    }
}
