using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IDocumentService
    {
        //Home page//
        public Task<ActionResult<List<RecentlyActivtiesView>>> GetRecentlyDocumentListAsync();

        public Task<RecentlyActivtiesView> GetDocumentDetailViewAsync(string DocumentId);
        public Task<string> AddDocumentListAsync(RecentlyActivtiesView model);
        //public Task UpdateDocumentListAsync(string NameDocument, DocumentView model);
        //public Task DeleteDocumentListAsync(string NameDocument);
        public Task<ActionResult<List<DocumentDetailView>>> GetAllDocumentDetailAsync();
        public Task<DocumentDetailView> GetOneDocumentDetailAsync(string NameDocument);
        //public Task<int> AddDocumentListAsync(DocumentDetailView model);
        public Task UpdateDocumentDetailAsync(string NameDocument, DocumentDetailView model);
        public Task DeleteDocumentDetailAsync(string NameDocument);
    }
}
