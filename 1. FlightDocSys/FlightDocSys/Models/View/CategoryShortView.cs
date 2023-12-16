namespace FlightDocSys.Models.View
{
    public class CategoryShortView
    {
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set;}
        public DateTime CreatedDate { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set;}
        public int GroupCount { get; set; }
    }
}
