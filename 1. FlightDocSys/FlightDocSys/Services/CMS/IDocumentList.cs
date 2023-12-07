using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS
{
    public interface IDocumentList
    {
        public Task<ActionResult<List<DocumentListView>>> getAllDocumentListAsync();
        public Task<DocumentListView> getDocumentDetailViewAsync(string NameDocument);
        //public Task<int> AddDocumentListAsync(DocumentListView model);
        public Task UpdateDocumentListAsync(string NameDocument, DocumentListView model);
        public Task DeleteDocumentListAsync(string NameDocument);
    }
}
