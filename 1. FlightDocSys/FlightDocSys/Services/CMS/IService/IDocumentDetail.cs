using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IDocumentDetail
    {
        public Task<ActionResult<List<DocumentDetailView>>> GetAllDocumentDetailAsync();
        public Task<DocumentDetailView> GetOneDocumentDetailAsync(string NameDocument);
        //public Task<int> AddDocumentListAsync(DocumentDetailView model);
        public Task UpdateDocumentDetailAsync(string NameDocument, DocumentDetailView model);
        public Task DeleteDocumentDetailAsync(string NameDocument);
    }
}
