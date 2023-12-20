using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.FileHandler
{
    public interface IFileService
    {
        public Task PostFileAsync(IFormFile fileData, DocumentFileView model);

        //public Task PostMultiFileAsync(List<DocumentDetailView> fileData);

        public Task<DownloadView> DownloadFileById(string Id);
    }
}
