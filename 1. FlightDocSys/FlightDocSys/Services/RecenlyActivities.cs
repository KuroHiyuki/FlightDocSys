using FlightDocSys.Models;
using FlightDocSys.Models.Context;
using FlightDocSys.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace FlightDocSys.Services
{
    public class RecenlyActivities : IRecentlyActivities
    {
        private readonly FlightDocSysContext _context;

        public RecenlyActivities(FlightDocSysContext context) 
        {
            _context = context;

        }
        public async Task<List<Document>> getAllDocumentAsync()
        {
            return await _context.Documents.ToListAsync();
        }

        Task<List<System.Reflection.Metadata.Document>> IRecentlyActivities.getAllDocumentAsync()
        {
            throw new NotImplementedException();
        }
    }
}
