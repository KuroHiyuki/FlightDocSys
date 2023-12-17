namespace FlightDocSys.Models.View
{
    public class GroupDetailView
    {
        public string? GroupId { get; set; } = Guid.NewGuid().ToString();
        public string? GroupName { get; set;}
        public string? Note {  get; set;}

    }
}
