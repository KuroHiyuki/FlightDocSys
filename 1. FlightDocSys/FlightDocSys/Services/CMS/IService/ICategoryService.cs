using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface ICategoryService
    {
        public Task<ActionResult<List<CategoryView>>> GetAllDocumentTypeListAsync();
        public Task<CategoryView> GetOneDocumentTypeViewAsync(string? id);
        public Task<string?> AddDocumentTypeListAsync(CategoryView model);
        public Task UpdateDocumentTypeListAsync(string? id, CategoryView model);
        public Task DeleteDocumentTypeListAsync(string? id);
    }
}
