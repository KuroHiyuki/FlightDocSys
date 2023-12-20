using FlightDocSys.FileHandler;
using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface IDocumentService
    {
        #region Short View
        public Task<ActionResult<List<DocumentShortView>>> GetAllDocumentAsync();
        public Task<DocumentShortView> GetDocumentByIdAsync(string id);
        #endregion

        #region Detail View
        public Task<ActionResult<List<DocumentDetailView>>> GetAllDocumentDetailAsync();
        public Task<DocumentDetailView> GetDocumentDetailByIdAsync(string id);
        public Task<string> AddDocumentAsync(DocumentDetailView model);
        public Task UpdateDocumentAsync(string id, DocumentUpdateView_1 model);
        public Task DeleteDocumentAsync(string id);
        public Task PostFileAsync(IFormFile fileData, DocumentFileView model);
        public Task UpdateFileAsync(IFormFile fileData, DocumentUpdateView_2 model);
        public Task<DownloadView> DownloadFileById(string Id);
        #endregion
    }
}
