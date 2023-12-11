namespace FlightDocSys.Models.View
{
    public class GroupPermissionView
    {
        public string GroupName { get; set; } = null!;
        public int Member {  get; set; }
        public DateTime CreatedDate { get; set; }
        public string Note { get; set; } = null!;
        public string UserName { get; set; } = null!;

    }
}
