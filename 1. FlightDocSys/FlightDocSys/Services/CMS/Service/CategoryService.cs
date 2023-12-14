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
        public Task<string?> AddDocumentTypeListAsync(CategoryView model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDocumentTypeListAsync(string? id)
        {
            var deleteDocumentType = await _context.Categorys.SingleOrDefaultAsync(b => b.CategoryId == id);
            if (deleteDocumentType != null)
            {
                var relatedUserDocuments = _context.GroupCategories.Where(ud => ud.CategoryId == deleteDocumentType.CategoryId);
                _context.GroupCategories.RemoveRange(relatedUserDocuments);
                _context.Categorys.Remove(deleteDocumentType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<List<CategoryView>>> GetAllDocumentTypeListAsync()
        {
            var Document = await _context.Categorys
                .Include(dt => dt.GroupCategories)
                .ThenInclude(dt => dt.Group)
                .Include(dt => dt.User)
                .ToListAsync();
            return _mapper.Map<List<CategoryView>>(Document!);
        }

        public async Task<CategoryView> GetOneDocumentTypeViewAsync(string? id)
        {
            var Document = await _context.Categorys
                .Include(dt => dt.GroupCategories)
                .ThenInclude(dt => dt.Group)
                .Include(dt => dt.User)
                .FirstOrDefaultAsync(dt => dt.CategoryId == id);
            return _mapper.Map<CategoryView>(Document);
        }

        public async Task UpdateDocumentTypeListAsync(string? id, CategoryView model)
        {
            if (id == model.Document_TypeId)
            {
                var updateDocumentType = _mapper.Map<Category>(model);
                _context.Categorys.Update(updateDocumentType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
