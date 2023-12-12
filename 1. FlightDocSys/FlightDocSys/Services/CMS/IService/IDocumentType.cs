using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IDocumentType
    {
        public Task<ActionResult<List<DocumentTypeView>>> GetAllDocumentTypeListAsync();
        public Task<DocumentTypeView> GetOneDocumentTypeViewAsync(string? id);
        public Task<string?> AddDocumentTypeListAsync(DocumentTypeView model);
        public Task UpdateDocumentTypeListAsync(string? id, DocumentTypeView model);
        public Task DeleteDocumentTypeListAsync(string? id);
    }
}
