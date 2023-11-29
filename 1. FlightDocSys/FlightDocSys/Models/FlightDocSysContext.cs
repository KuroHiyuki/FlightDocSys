using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlightDocSys.Models
{
    public partial class FlightDocSysContext : DbContext
    {
      

        protected readonly IConfiguration Configuration;

        public FlightDocSysContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
   
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupPermission> GroupPermissions { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Route> Routes { get; set; } = null!;
        public virtual DbSet<TypeDo> TypeDos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserGroup> UserGroups { get; set; } = null!;


        #region CreateModel
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

                entity.Property(e => e.TypeDoId).HasColumnName("TypeDoID");

                entity.Property(e => e.Version)
                    .HasColumnType("decimal(18, 1)")
                    .HasDefaultValueSql("((1.0))");
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
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("GROUP");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("GroupID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Note).HasColumnType("text");

                entity.HasMany(d => d.Documents)
                    .WithMany(p => p.Groups)
                    .UsingEntity<Dictionary<string, object>>(
                        "GroupDocument",
                        l => l.HasOne<Document>().WithMany().HasForeignKey("DocumentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DOCUMENT_G"),
                        r => r.HasOne<Group>().WithMany().HasForeignKey("GroupId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_GROUP_D"),
                        j =>
                        {
                            j.HasKey("GroupId", "DocumentId");

                            j.ToTable("GROUP_DOCUMENT");

                            j.IndexerProperty<int>("GroupId").HasColumnName("GroupID");

                            j.IndexerProperty<int>("DocumentId").HasColumnName("DocumentID");
                        });
            });

            modelBuilder.Entity<GroupPermission>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.PermissionId });

                entity.ToTable("GROUP_PERMISSION");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupPermissions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GROUP");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.GroupPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMISSION_G");
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

                entity.HasMany(d => d.Permissions)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "RolePermission",
                        l => l.HasOne<Permission>().WithMany().HasForeignKey("PermissionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PERMISSION"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ROLE"),
                        j =>
                        {
                            j.HasKey("RoleId", "PermissionId");

                            j.ToTable("ROLE_PERMISSION");

                            j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");

                            j.IndexerProperty<int>("PermissionId").HasColumnName("PermissionID");
                        });
            });

            modelBuilder.Entity<Route>(entity =>
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

            modelBuilder.Entity<TypeDo>(entity =>
            {
                entity.ToTable("TypeDo");

                entity.Property(e => e.TypeDoId)
                    .ValueGeneratedNever()
                    .HasColumnName("TypeDoID");

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

                entity.HasMany(d => d.Documents)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserDocument",
                        l => l.HasOne<Document>().WithMany().HasForeignKey("DocumentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DOCUMENT_U"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_USER_D"),
                        j =>
                        {
                            j.HasKey("UserId", "DocumentId");

                            j.ToTable("USER_DOCUMENT");

                            j.IndexerProperty<int>("UserId").HasColumnName("UserID");

                            j.IndexerProperty<int>("DocumentId").HasColumnName("DocumentID");
                        });

                entity.HasMany(d => d.Flights)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserFlight",
                        l => l.HasOne<Flight>().WithMany().HasForeignKey("FlightId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FLIGHT"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_USER"),
                        j =>
                        {
                            j.HasKey("UserId", "FlightId");

                            j.ToTable("USER_FLIGHT");

                            j.IndexerProperty<int>("UserId").HasColumnName("UserID");

                            j.IndexerProperty<int>("FlightId").HasColumnName("FlightID");
                        });
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GroupId });

                entity.ToTable("USER_GROUP");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.UserGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GROUP_U");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_G");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        #endregion
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
