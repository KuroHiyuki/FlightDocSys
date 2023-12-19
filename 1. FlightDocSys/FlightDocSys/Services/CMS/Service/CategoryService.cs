using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public CategoryService(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult<List<CategoryShortView>>> GetAllCategoryAsync()
        {
            var Document = await _context.Categorys
                .Include(dt => dt.GroupCategories)
                .Include(dt => dt.User)
                .ToListAsync();
            return _mapper.Map<List<CategoryShortView>>(Document!);
        }
        public async Task<CategoryShortView> GetCategoryByIdAsync(string id)
        {
            var Document = await _context.Categorys
                .Include(dt => dt.GroupCategories)
                .Include(dt => dt.User)
                .FirstOrDefaultAsync(dt => dt.CategoryId == id);
            return _mapper.Map<CategoryShortView>(Document);
        }
        public async Task<CategoryDetailView> AddCategoryAsync(CategoryDetailView model)
        {
            var Document = _mapper.Map<Category>(model);
            Document.CategoryId = Guid.NewGuid().ToString();
            _context.Categorys!.Add(Document);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryDetailView>(Document);
        }

        public async Task DeleteCategoryAsync(string? id)
        {
            var Document = await _context.Categorys.SingleOrDefaultAsync(b => b.CategoryId == id);
            if (Document != null)
            {
                _context.Categorys.Remove(Document);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ActionResult<List<CategoryDetailView>>> GetAllCategoryDetailAsync()
        {
            var Document = await _context.Categorys
                .ToListAsync();
            return _mapper.Map<List<CategoryDetailView>>(Document!);
        }

        public async Task<CategoryDetailView> GetCategoryDetailByIdAsync(string id)
        {
            var Document = await _context.Categorys
                .FirstOrDefaultAsync(dt => dt.CategoryId == id);
            return _mapper.Map<CategoryDetailView>(Document!);
        }

        public async Task UpdateCategoryAsync(string id, CategoryDetailView model)
        {
            var checkId = await _context.Categorys.FindAsync(id);
            if(checkId != null)
            {
                var update = _mapper.Map<Category>(model);
                _context.Categorys.Update(update);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    _context.RemoveRange();
                }
            }  
        }
    }
}
