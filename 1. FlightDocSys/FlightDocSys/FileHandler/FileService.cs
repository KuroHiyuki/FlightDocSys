using AutoMapper;
using FlightDocSys.ErrorThrow;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace FlightDocSys.FileHandler
{
    public class FIleService : IFileService
    {
        private readonly FlightDocSysContext _context;
        private readonly IMapper _mapper;

        public FIleService(FlightDocSysContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DownloadView> DownloadFileById(string Id)
        {

            var file = _context.Documents.Where(x => x.DocumentId == Id).FirstOrDefaultAsync();
            if(file==null)
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
                    throw new ExceptionThrow(410, "Nhập thiếu thông tin bắt buộc");
                }
                var fileDetails = _mapper.Map<Document>(model);
                fileDetails.DocumentId = Guid.NewGuid().ToString();
                fileDetails.Version = (decimal)1.0;
                fileDetails.UpdatedDate = DateTime.Now;
                fileDetails.Name =  fileData.FileName ?? model.Name;
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
        //public async Task CopyStream(Stream stream, string downloadPath)
        //{
        //    using var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write);
        //    await stream.CopyToAsync(fileStream);
        //}
    }
}
