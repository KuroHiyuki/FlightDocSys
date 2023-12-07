using AutoMapper;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightDocSys.Services.CMS
{
    public class DocumentTypeList : IDocumentTypeList
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public DocumentTypeList(FlightDocSysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddDocumentTypeListAsync(DocumentTypeListView model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDocumentTypeListAsync(int id)
        {
            var deleteDocumentType = await _context.Document_Types.SingleOrDefaultAsync(b => b.Document_TypeId == id);
            if (deleteDocumentType != null)
            {
                var relatedUserDocuments = _context.GroupDocumentTypes.Where(ud => ud.Document_TypeId == deleteDocumentType.Document_TypeId);
                _context.GroupDocumentTypes.RemoveRange(relatedUserDocuments);
                _context.Document_Types.Remove(deleteDocumentType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<List<DocumentTypeListView>>> getAllDocumentTypeListAsync()
        {
            var Document = await _context.Document_Types
                .Include(dt => dt.GroupDocumenttypes)
                .ThenInclude(dt => dt.Group)
                .Include(dt => dt.User)
                .ToListAsync();
            return _mapper.Map<List<DocumentTypeListView>>(Document!);
        }

        public async Task<DocumentTypeListView> getOneDocumentTypeViewAsync(int id)
        {
            var Document = await _context.Document_Types
                .Include(dt => dt.GroupDocumenttypes)
                .ThenInclude(dt => dt.Group)
                .Include(dt => dt.User)
                .FirstOrDefaultAsync(dt => dt.Document_TypeId == id);
            return _mapper.Map<DocumentTypeListView>(Document);
        }

        public async Task UpdateDocumentTypeListAsync(int id, DocumentTypeListView model)
        {
            if (id == model.Document_TypeId)
            {
                var updateDocumentType = _mapper.Map<Document_Type>(model);
                _context.Document_Types.Update(updateDocumentType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
