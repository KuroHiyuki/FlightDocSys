using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS.Service
{
    public class DocumentDetail : IDocumentDetail
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public DocumentDetail(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task DeleteDocumentDetailAsync(string NameDocument)
        {
            var deleteDocumentDetail = await _context.Documents.SingleOrDefaultAsync(b => b.Name == NameDocument);
            if (deleteDocumentDetail != null)
            {
                var relatedUserDocuments = _context.UserDocuments.Where(ud => ud.DocumentId == deleteDocumentDetail.DocumentId);
                _context.UserDocuments.RemoveRange(relatedUserDocuments);
                _context.Documents.Remove(deleteDocumentDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<List<DocumentDetailView>>> GetAllDocumentDetailAsync()
        {
            var Document = await _context.Documents
                .Include(document => document.Document_Type)
                .Include(document => document.UserDocuments)
                .ThenInclude(document => document.User)
                .ToListAsync();
            return _mapper.Map<List<DocumentDetailView>>(Document!);
        }

        public async Task<DocumentDetailView> GetOneDocumentDetailAsync(string NameDocument)
        {
            var Document = await _context.Documents
                .Include(document => document.Document_Type)
                .Include(document => document.UserDocuments)
                .ThenInclude(document => document.User)
                .FirstOrDefaultAsync(document => document.Name == NameDocument);
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
    }
}
