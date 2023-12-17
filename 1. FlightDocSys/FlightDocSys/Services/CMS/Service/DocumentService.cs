using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;
       

        public DocumentService(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DocumentShortView> GetDocumentByIdAsync(string id)
        {
            var Document = await _context.Documents
                .Include(document => document.Flight)
                .Include(document => document.Category)
                .Include(document => document.User)
                .FirstOrDefaultAsync(document => document.DocumentId == id);
            return _mapper.Map<DocumentShortView>(Document);
        }
        public async Task<ActionResult<List<DocumentShortView>>> GetAllDocumentAsync()
        {
            var Document = await _context.Documents
                .Include(document => document.Flight)
                .Include(document => document.Category)
                .Include(document => document.User)
                .ToListAsync();
            return _mapper.Map<List<DocumentShortView>>(Document);
        }
        public async Task<string> AddDocumentAsync(DocumentDetailView model)
        {
            var AddDocument = _mapper.Map<Document>(model);
            await _context.Documents!.AddAsync(AddDocument);
            await _context.SaveChangesAsync();
            return AddDocument.DocumentId!;
        }
        public async Task DeleteDocumentAsync(string id)
        {
            var deleteDocumentDetail = await _context.Documents.SingleOrDefaultAsync(b => b.DocumentId == id);
            if (deleteDocumentDetail != null)
            {
                _context.Documents.Remove(deleteDocumentDetail);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ActionResult<List<DocumentDetailView>>> GetAllDocumentDetailAsync()
        {
            var Document = await _context.Documents
                .ToListAsync();
            return _mapper.Map<List<DocumentDetailView>>(Document);
        }
        public async Task<DocumentDetailView> GetDocumentDetailByIdAsync(string id)
        {
            var Document = await _context.Documents
                .FirstOrDefaultAsync(document => document.DocumentId == id);
            return _mapper.Map<DocumentDetailView>(Document);
        }
        public async Task UpdateDocumentAsync(string id, DocumentDetailView model)
        {
            var checkId = await _context.Documents.FindAsync(id);
            if (checkId != null)
            {
                var updateDocumentDetail = _mapper.Map<Document>(model);
                _context.Documents.Update(updateDocumentDetail);
                await _context.SaveChangesAsync();
            }
            
        }
        
    }
}
