using FlightDocSys.Models;

namespace FlightDocSys.Profiles.DTOModels
{
    public class DocumentDTO
    {
        /*public DocumentDTO()
        {
            Groups = new HashSet<Group>();
            Users = new HashSet<User>();
        }
        */
        public int DocumentId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public decimal Version { get; set; }
        public string Filepath { get; set; } = null!;
        public string? Note { get; set; }
        public int FlightId { get; set; }
        public int TypeDoId { get; set; }

        //public virtual ICollection<Group> Groups { get; set; }
        //public virtual ICollection<User> Users { get; set; }
    }
}
