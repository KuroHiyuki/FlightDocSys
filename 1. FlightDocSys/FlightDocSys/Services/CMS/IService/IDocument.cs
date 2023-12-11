using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IDocument
    {
        public Task<ActionResult<List<DocumentView>>> GetAllDocumentListAsync();
        public Task<DocumentView> GetDocumentDetailViewAsync(string NameDocument);
        //public Task<int> AddDocumentListAsync(DocumentListView model);
        //public Task UpdateDocumentListAsync(string NameDocument, DocumentView model);
        //public Task DeleteDocumentListAsync(string NameDocument);
    }
}
