namespace FlightDocSys.Models.View
{
    public class PermissionView
    {
        public string? PermissionId { get; set; } = Guid.NewGuid().ToString();
        public string? PermissionName { get; set;}
    }
}
