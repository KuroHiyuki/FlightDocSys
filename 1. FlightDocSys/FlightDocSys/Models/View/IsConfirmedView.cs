namespace FlightDocSys.Models.View
{
    public class IsConfirmedView
    {
        public string? DocumentId { get; set; }
        public DateTime ConfirmDate { get; set; } = DateTime.Now;
        public string? Signature { get; set; }

    }
}
