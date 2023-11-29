using Microsoft.EntityFrameworkCore;
using FlightDocSys.Models.Entity;
using FlightDocSys.Models.Relation;


namespace FlightDocSys.Models.DBContext
{
    public class FlightDocDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public FlightDocDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        #region DBSet
        public DbSet<USER> USER { get; set; }
        public DbSet<DOCUMENT> DOCUMENT { get; set; }
        public DbSet<FLIGHT> FLIGHT { get; set; }
        public DbSet<GROUP> GROUP { get; set; }
        public DbSet<PERMISSION> PERMISSION { get; set; }
        public DbSet<ROLE> ROLE { get; set; }
        public DbSet<ROUTE> ROUTE { get; set; }
        public DbSet<TYPE> TYPE { get; set; }
        public DbSet<GROUP_PERMISSION> GROUP_PERMISSION { get; set; }
        public DbSet<GROUP_TYPE> GROUP_TYPE { get; set; }
        public DbSet<ROLE_PERMISSION> ROLE_PERMISSION { get; set; }
        public DbSet<USER_DOCUMENT> USER_DOCUMENT { get; set; }
        public DbSet<USER_FLIGHT> USER_FLIGHT { get; set; }
        public DbSet<USER_GROUP> USER_GROUP { get; set; }
        #endregion

    }
}
