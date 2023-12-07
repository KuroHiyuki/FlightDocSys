using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS
{
    public interface IDocumentTypeList
    {
        public Task<ActionResult<List<DocumentTypeListView>>> getAllDocumentTypeListAsync();
        public Task<DocumentTypeListView> getOneDocumentTypeViewAsync(int id);
        public Task<int> AddDocumentTypeListAsync(DocumentTypeListView model);
        public Task UpdateDocumentTypeListAsync(int id, DocumentTypeListView model);
        public Task DeleteDocumentTypeListAsync(int id);
    }
}
