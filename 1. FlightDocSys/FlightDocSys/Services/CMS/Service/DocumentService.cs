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


        public async Task<ActionResult<List<DocumentView>>> GetAllDocumentListAsync()
        {
            var Document = await _context.Documents
                .Include(document => document.Flight)
                .Include(document => document.Category)
                .Include(document => document.User)
                .ToListAsync();
            return _mapper.Map<List<DocumentView>>(Document!);
        }

        public async Task<DocumentView> GetDocumentDetailViewAsync(string NameDocument)
        {
            var Document = await _context.Documents
                .Include(document => document.Flight)
                .Include(document => document.Category)
                .Include(document => document.User)
                .FirstOrDefaultAsync(document => document.DocumentId == NameDocument);
            return _mapper.Map<DocumentView>(Document);
        }

        public async Task DeleteDocumentDetailAsync(string NameDocument)
        {
            var deleteDocumentDetail = await _context.Documents.SingleOrDefaultAsync(b => b.Name == NameDocument);
            if (deleteDocumentDetail != null)
            {
                //var relatedUserDocuments = _context.UserDocuments.Where(ud => ud.DocumentId == deleteDocumentDetail.DocumentId);
                //_context.UserDocuments.RemoveRange(relatedUserDocuments);
                _context.Documents.Remove(deleteDocumentDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<List<DocumentDetailView>>> GetAllDocumentDetailAsync()
        {
            var Document = await _context.Documents
                .Include(document => document.Category)
                .Include(document => document.User)
                .ToListAsync();
            return _mapper.Map<List<DocumentDetailView>>(Document!);
        }

        public async Task<DocumentDetailView> GetOneDocumentDetailAsync(string DocumentId)
        {
            var Document = await _context.Documents
                .Include(document => document.Category)
                .Include(document => document.User)
                .FirstOrDefaultAsync(document => document.DocumentId == DocumentId);
            return _mapper.Map<DocumentDetailView>(Document!);
        }

        public async Task UpdateDocumentDetailAsync(string NameDocument, DocumentDetailView model)
        {
            if (NameDocument == model.DocumentName)
            {
                var updateDocumentDetail = _mapper.Map<FlightDocSys.Models.Entities.Document>(model);
                _context.Documents.Update(updateDocumentDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> AddDocumentListAsync(DocumentView model)
        {
            var Document = new Document
            {
                DocumentId = Guid.NewGuid().ToString(),
                Name = model.DocumentName,
                UpdatedDate = DateTime.Now,
                Note = "",
                FileType = model.DocumentName!.Split('.')[1],
            };
            _context.Documents!.Add(Document);
            await _context.SaveChangesAsync();
            return Document.DocumentId!;
        }
    }
}
