using System.Reflection.Metadata;

namespace FlightDocSys.Services
{
    public interface IRecentlyActivities
    {
        public Task<List<Document>> getAllDocumentAsync();
    }
}
