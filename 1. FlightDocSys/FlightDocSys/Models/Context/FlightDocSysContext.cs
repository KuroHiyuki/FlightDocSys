using Microsoft.EntityFrameworkCore;
using System;
using FlightDocSys.Models.Entities;
using FlightDocSys.Models.Relation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FlightDocSys.Authentication;
using Microsoft.AspNetCore.Identity;
using FlightDocSys.Models.Enities;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace FlightDocSys.Models.Context
{
    public partial class FlightDocSysContext : IdentityDbContext<User>
    {
        public FlightDocSysContext()
        {
        }

        public FlightDocSysContext(DbContextOptions<FlightDocSysContext> options)
            : base(options)
        {
        }
        #region Dbcontext Enities
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Category> Categorys { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<IsConfirmed> IsConfirmeds { get; set; } = null!;        
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Entities.Route> Routes { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;

        #endregion

        #region Dbcontext Relation
        public virtual DbSet<GroupPermission> GroupPermissions { get; set; } = null!;
        public virtual DbSet<GroupCategory> GroupCategories { get; set; } = null!;
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
            base.OnModelCreating(modelBuilder);

            #region Setting
            modelBuilder.Entity<Setting>(Entity =>
            {
                Entity.ToTable("SETTING");
                Entity.HasKey(e => e.UserId)
                    .HasName("PK_UserId");

                Entity.Property(e => e.Theme)
                    .IsRequired()
                    .HasColumnName("Theme");

                Entity.Property(e => e.NameLogo)
                    .HasColumnName("NameLogo");

                Entity.Property(e => e.FilePath)
                    .HasColumnName("FilePath");
            });
            #endregion

            #region Document
            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("DOCUMENT");

                entity.Property(e => e.DocumentId)
                    .HasColumnName("DocumentID");
                entity.HasKey(e => e.DocumentId);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DateTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Note).HasColumnName("Note");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryId");

                entity.Property(e => e.Version)
                    .HasColumnType("decimal(18, 1)")
                    .HasDefaultValueSql("((1.0))");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserId");

                entity.Property(e => e.FileType)
                    .HasColumnName("FileType");
           
                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_F");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_T");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_U");

                entity.HasOne(d => d.IsConfirmed)
                    .WithOne(p => p.Document)
                    .HasForeignKey<IsConfirmed>(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IsConfirm_Document");
            });
            #endregion

            #region Flight
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("FLIGHT");

                entity.Property(e => e.FlightId)
                     .ValueGeneratedNever()
                    .HasColumnName("FlightID");

                entity.Property(e => e.DeparturedDate).HasColumnType("DateTime");

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
            #endregion

            #region Group
            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("GROUP");

                entity.Property(e => e.GroupId)
                     .ValueGeneratedNever()
                    .HasColumnName("GroupID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Note).HasColumnType("text");

            });
            #endregion

            #region Permission
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("PERMISSION");

                entity.Property(e => e.PermissionId)
                     .ValueGeneratedNever()
                    .HasColumnName("PermissionID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });
            #endregion

            #region Route
            modelBuilder.Entity<Entities.Route>(entity =>
            {
                entity.ToTable("ROUTE");

                entity.Property(e => e.RouteId)
                    .HasMaxLength(10)
                    .HasColumnName("RouteID");

                entity.Property(e => e.PointOfloading)
                    .HasMaxLength(100)
                    .HasColumnName("PointOFLoading");

                entity.Property(e => e.PointOfunloading)
                    .HasMaxLength(100)
                    .HasColumnName("PointOFUnloading");
                entity.Property(e => e.Duration)
                    .HasColumnType("decimal(18, 9)");
            });
            #endregion

            #region Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.CategoryId)
                     .ValueGeneratedNever()
                    .HasColumnName("CategoryId");

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
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_U");
            });
            #endregion

            #region User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.UserId)
                     .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.Setting)
                    .WithOne(p => p.User)
                    .HasForeignKey<Setting>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Setting_User");
            });
            #endregion

            #region History
            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("HISTORY");

                entity.Property(e => e.HistoryId)
                     .ValueGeneratedNever()
                    .HasColumnName("HistoryId");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DateTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.Version)
                    .HasColumnType("decimal(18, 1)")
                    .HasDefaultValueSql("((1.0))");

                entity.Property(e => e.DocumentId)
                    .HasColumnName("DocumentId");

                entity.Property(e => e.FileType)
                    .HasColumnName("FileType");
                
                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_D");
            });
            #endregion

            #region IsConfirmed
            modelBuilder.Entity<IsConfirmed>(Entity =>
            {
                Entity.ToTable("IsConfirmed");

                Entity.HasKey(e => e.DocumentId)
                    .HasName("DocumentId");

                Entity.Property(e => e.UpdatedDate)
                    .HasColumnType("DateTime")
                    .HasDefaultValueSql("(getdate())");
            });
            #endregion

            #region Group Permission
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
            #endregion

            #region Group Category
            modelBuilder.Entity<GroupCategory>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.CategoryId });

                entity.ToTable("GROUP_CATEGORY");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryId");

                entity.HasOne(d => d.Group)
                     .WithMany(p => p.GroupCategories)
                     .HasForeignKey(d => d.GroupId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_GROUP_Category");

                entity.HasOne(d => d.Category)
                     .WithMany(p => p.GroupCategories)
                     .HasForeignKey(d => d.CategoryId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_Category_GROUP");

            });
            #endregion

            #region User Flight
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
            #endregion

            #region User Group
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
            #endregion

            OnModelCreatingPartial(modelBuilder);
        }
        #endregion
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
