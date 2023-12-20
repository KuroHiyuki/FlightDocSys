using AutoMapper;
using FlightDocSys.ErrorThrow;
using FlightDocSys.FileHandler;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using FlightDocSys.Services.CMS.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
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
        public async Task<DownloadView> DownloadFileById(string Id)
        {
            var file = _context.Documents.Where(x => x.DocumentId == Id).FirstOrDefaultAsync();
            if (file == null)
            {
                throw new ExceptionThrow(410, "Tài liệu không tồn tại");
            };
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "FileHandler\\Document", file.Result!.Name!);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            var DownloadItem = new DownloadView
            {
                Data = bytes,
                Content = contenttype,
                Filepath = Path.GetFileName(filepath)
            };
            return DownloadItem;

        }

        public async Task PostFileAsync(IFormFile fileData, DocumentFileView model)
        {
            try
            {
                if (model.CategoryId == null || model.UserId == null || model.FlightId == null)
                {
                    throw new ExceptionThrow(410, "Nhập thiếu thông tin bắt buộc: Flight ID, Category ID và User ID là bắt buộc");
                }
                var fileDetails = _mapper.Map<Document>(model);
                fileDetails.DocumentId = Guid.NewGuid().ToString();
                fileDetails.Version = (decimal)1.0;
                fileDetails.UpdatedDate = DateTime.Now;
                fileDetails.Name = fileData.FileName ?? model.Name;
                string[] parts = fileData.FileName!.Split(".");
                fileDetails.FileType = parts[1] switch
                {
                    "pdf" => (FileType)1,
                    "docx" => (FileType)2,
                    _ => 0,
                };
                if (fileDetails.FileType == 0)
                {
                    throw new ExceptionThrow(405, "Kiểu File không hợp lệ");
                }
                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "FileHandler\\Document", fileDetails.Name!);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await fileData.CopyToAsync(stream);
                }
                var result = await _context.Documents.AddAsync(fileDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
