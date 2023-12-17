using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocSys.Services.CMS.IService
{
    public interface ICategoryService
    {
        #region Short View
        public Task<ActionResult<List<CategoryShortView>>> GetAllCategoryAsync();
        public Task<CategoryShortView> GetCategoryByIdAsync(string id);
        #endregion

        #region Detail View
        public Task<ActionResult<List<CategoryDetailView>>> GetAllCategoryDetailAsync();
        public Task<CategoryDetailView> GetCategoryDetailByIdAsync(string id);
        public Task<CategoryDetailView> AddCategoryAsync(CategoryDetailView model);
        public Task UpdateCategoryAsync(string id, CategoryDetailView model);
        public Task DeleteCategoryAsync(string id);
        #endregion
    }
}
