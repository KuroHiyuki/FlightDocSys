using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IDocumentType
    {
        public Task<ActionResult<List<DocumentTypeView>>> GetAllDocumentTypeListAsync();
        public Task<DocumentTypeView> GetOneDocumentTypeViewAsync(int id);
        public Task<int> AddDocumentTypeListAsync(DocumentTypeView model);
        public Task UpdateDocumentTypeListAsync(int id, DocumentTypeView model);
        public Task DeleteDocumentTypeListAsync(int id);
    }
}
