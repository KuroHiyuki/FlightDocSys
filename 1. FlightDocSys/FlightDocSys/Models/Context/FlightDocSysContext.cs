using Microsoft.EntityFrameworkCore;
using System;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.Relation;

namespace FlightDocSys.Models.Context
{
    public partial class FlightDocSysContext : DbContext
    {
        public FlightDocSysContext()
        {
        }

        public FlightDocSysContext(DbContextOptions<FlightDocSysContext> options)
            : base(options)
        {
        }
        #region Dbcontext Enities

        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Document_Type> Document_Types { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Entities.Route> Routes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;

        #endregion

        #region Dbcontext Relation
        public virtual DbSet<GroupPermission> GroupPermissions { get; set; } = null!;
        public virtual DbSet<GroupDocumenttype> GroupDocumentTypes { get; set; } = null!;
        public virtual DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public virtual DbSet<UserDocument> UserDocuments { get; set; } = null!;
        public virtual DbSet<UserFlight> UserFlights { get; set; } = null!;
        public virtual DbSet<UserGroup> UserGroups { get; set; } = null!;
 
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=KURO;Initial Catalog=FlightDocSys;Integrated Security=True;User Instance=False");
            }
        }
        #region CreateModel
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>(Entity =>
            {
                Entity.ToTable("SETTING");
                Entity.HasKey(e => e.UserId)
                    .HasName("PK_UserId");
                Entity.Property(e => e.Theme)
                    .IsRequired()
                    .HasColumnName("Theme");
                Entity.Property(e => e.Logo)
                    .HasColumnName("Logo");
            });
            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("DOCUMENT");

                entity.Property(e => e.DocumentId)
                    .ValueGeneratedNever()
                    .HasColumnName("DocumentID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.Document_TypeId).HasColumnName("TypeDoID");

                entity.Property(e => e.Version)
                    .HasColumnType("decimal(18, 1)")
                    .HasDefaultValueSql("((1.0))");
                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_F");
                entity.HasOne(d => d.Document_Type)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.Document_TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_T");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("FLIGHT");

                entity.Property(e => e.FlightId)
                    .ValueGeneratedNever()
                    .HasColumnName("FlightID");

                entity.Property(e => e.DepartureDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.RouteId)
                    .HasMaxLength(10)
                    .HasColumnName("RouteID");
                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flight_R");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("GROUP");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("GroupID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Note).HasColumnType("text");

            });
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("PERMISSION");

                entity.Property(e => e.PermissionId)
                    .ValueGeneratedNever()
                    .HasColumnName("PermissionID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Entities.Route>(entity =>
            {
                entity.ToTable("ROUTE");

                entity.Property(e => e.RouteId)
                    .HasMaxLength(10)
                    .HasColumnName("RouteID");

                entity.Property(e => e.PointOfloading)
                    .HasMaxLength(50)
                    .HasColumnName("PointOFLoading");

                entity.Property(e => e.PointOfunloading)
                    .HasMaxLength(50)
                    .HasColumnName("PointOFUnloading");
            });

            modelBuilder.Entity<Document_Type>(entity =>
            {
                entity.ToTable("DOCUMENT_TYPE");

                entity.Property(e => e.Document_TypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Document_TypeId");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Document_Types)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_Type_U");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(50);

                entity.Property(e => e.PasswordSalt).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                     .WithMany(p => p.Users)
                     .HasForeignKey(d => d.RoleId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_USER_ROLE");
                entity.HasOne(d => d.Setting)
                    .WithOne(p => p.User)
                    .HasForeignKey<Setting>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Setting_User");
            });

            modelBuilder.Entity<GroupPermission>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.PermissionId });

                entity.ToTable("GroupPermission");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
                entity.HasOne(d => d.Group)
                     .WithMany(p => p.GroupPermissions)
                     .HasForeignKey(d => d.GroupId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_GROUP_PERMISSION");
                entity.HasOne(d => d.Permission)
                     .WithMany(p => p.GroupPermissions)
                     .HasForeignKey(d => d.PermissionId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_PERMISSION_GROUP");
            });
            modelBuilder.Entity<GroupDocumenttype>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.Document_TypeId });

                entity.ToTable("GroupDocumenttype");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Document_TypeId).HasColumnName("Document_TypeId");
                entity.HasOne(d => d.Group)
                     .WithMany(p => p.GroupDocumenttypes)
                     .HasForeignKey(d => d.GroupId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_GROUP_DOCUMENT_TYPE");
                entity.HasOne(d => d.Document_Type)
                     .WithMany(p => p.GroupDocumenttypes)
                     .HasForeignKey(d => d.Document_TypeId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_DOCUMENT_TYPE_GROUP");

            });
            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId });

                entity.ToTable("RolePermission");

                entity.Property(e => e.RoleId).HasColumnName("RoleId");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
                entity.HasOne(d => d.Role)
                     .WithMany(p => p.RolePermissions)
                     .HasForeignKey(d => d.RoleId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_ROLE_PERMISSION");
                entity.HasOne(d => d.Permission)
                     .WithMany(p => p.RolePermissions)
                     .HasForeignKey(d => d.PermissionId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_PERMISSION_ROLE");
            });
            modelBuilder.Entity<UserDocument>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DocumentId });

                entity.ToTable("UserDocument");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentId");
                entity.HasOne(d => d.User)
                     .WithMany(p => p.UserDocuments)
                     .HasForeignKey(d => d.UserId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_USER_DOCUMENT");
                entity.HasOne(d => d.Document)
                     .WithMany(p => p.UserDocuments)
                     .HasForeignKey(d => d.DocumentId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_DOCUMENT_USER");
            });

            modelBuilder.Entity<UserFlight>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FlightId });

                entity.ToTable("UserFlight");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.HasOne(d => d.User)
                     .WithMany(p => p.UserFlights)
                     .HasForeignKey(d => d.UserId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_USER_FLIGHT");
                entity.HasOne(d => d.Flight)
                     .WithMany(p => p.UserFlights)
                     .HasForeignKey(d => d.FlightId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_FLIGHT_USER");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GroupId });

                entity.ToTable("UserGroup");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
                entity.HasOne(d => d.User)
                     .WithMany(p => p.UserGroups)
                     .HasForeignKey(d => d.UserId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_USER_GROUP");
                entity.HasOne(d => d.Group)
                     .WithMany(p => p.UserGroups)
                     .HasForeignKey(d => d.GroupId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_GROUP_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        #endregion
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
