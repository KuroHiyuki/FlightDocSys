namespace FlightDocSys.Models.View
{
    public class CategoryDetailView
    {
        public string? CategoryId { get; set; } = Guid.NewGuid().ToString();
        public string? CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UserId { get; set; }
        public string? Note { get; set; }
    }
}
