using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlightDocSys.Services.CMS.Service
{
    public class Document : IDocument
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public Document(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public async Task DeleteDocumentListAsync(string NameDocument)
        //{
        //    var deleteDocument = await _context.Documents.SingleOrDefaultAsync(b => b.Name == NameDocument);
        //    if (deleteDocument != null)
        //    {
        //        var relatedUserDocuments = _context.UserDocuments.Where(ud => ud.DocumentId == deleteDocument.DocumentId);
        //        _context.UserDocuments.RemoveRange(relatedUserDocuments);
        //        _context.Documents.Remove(deleteDocument);
        //        await _context.SaveChangesAsync();
        //    }
        //}

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
                .FirstOrDefaultAsync(document => document.Name == NameDocument);
            return _mapper.Map<DocumentView>(Document);
        }

        //public async Task UpdateDocumentListAsync(string NameDocument, DocumentView model)
        //{
        //    var documents = _context.Documents.Where(d => d.Name == NameDocument);
        //    foreach (var document in documents)
        //    {
        //        var updateDocument = _mapper.Map<Models.Entities.Document>(model);
        //        _context.Entry(document).CurrentValues.SetValues(updateDocument);
        //    }
        //    await _context.SaveChangesAsync();
        //}
    }
}
