namespace FlightDocSys.Models.View
{
    public class DocumentTypeView
    {
        public int Document_TypeId { get; set; }
        public string Document_TypeName { get; set; } = null!;
        public string? Username { get; set; }
        public string? Despcription { get; set; }
        public string? GroupName { get; set; }
        //public - còn thiếu permission name hoặc Id để thực hiện chỉnh sửa
        public int CountPermission { get; set; }
    }
}

