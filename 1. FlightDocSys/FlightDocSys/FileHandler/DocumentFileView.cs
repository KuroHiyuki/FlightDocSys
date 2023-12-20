using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FlightDocSys.FileHandler
{
    public class DocumentFileView
    {
        public string? Name { get; set; }
        public string? Note { get; set; }
        public string? FlightId { get; set; }
        public string? CategoryId { get; set; }
        public string? UserId { get; set; }
        public string? PreviousDocumentId { get; set; } = null;
    }
    
    
}
