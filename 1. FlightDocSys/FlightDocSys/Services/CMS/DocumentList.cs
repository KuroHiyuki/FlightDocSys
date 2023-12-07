using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Linq;

namespace FlightDocSys.Services.CMS
{
    public class DocumentList : IDocumentList
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public DocumentList(FlightDocSysContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task DeleteDocumentListAsync(string NameDocument)
        {
            var deleteDocument = await _context.Documents.SingleOrDefaultAsync(b => b.Name == NameDocument);
            if(deleteDocument != null) 
            {
                var relatedUserDocuments = _context.UserDocuments.Where(ud => ud.DocumentId == deleteDocument.DocumentId);
                _context.UserDocuments.RemoveRange(relatedUserDocuments);

                _context.Documents.Remove(deleteDocument);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<List<DocumentListView>>> getAllDocumentListAsync()
        {
            var Document = await _context.Documents
                .Include(document => document.Flight)
                .Include(document => document.Document_Type)
                .Include(document => document.UserDocuments)
                .ThenInclude(document => document.User)
                .ToListAsync();
            return _mapper.Map<List<DocumentListView>>(Document!);
        }

        public async Task<DocumentListView> getDocumentDetailViewAsync(string NameDocument)
        {
            var Document = await _context.Documents
                .Include(document => document.Flight)
                .Include(document => document.Document_Type)
                .Include(document => document.UserDocuments)
                .ThenInclude(document => document.User)
                .FirstOrDefaultAsync(document => document.Name == NameDocument);
            return _mapper.Map<DocumentListView>(Document);
        }

        public async Task UpdateDocumentListAsync(string NameDocument, DocumentListView model)
        {
            if(NameDocument == model.DocumentName)
            {
                var updateDocument = _mapper.Map<Document> (model);
                _context.Documents.Update(updateDocument);
                await _context.SaveChangesAsync();
            }
        }
    }
}
