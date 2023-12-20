using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocSys.Migrations
{
    public partial class documentupload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GROUP",
                columns: table => new
                {
                    GroupID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSION",
                columns: table => new
                {
                    PermissionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSION", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "ROUTE",
                columns: table => new
                {
                    RouteID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PointOFLoading = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PointOFUnloading = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(18,9)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROUTE", x => x.RouteID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupPermission",
                columns: table => new
                {
                    GroupID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPermission", x => new { x.GroupID, x.PermissionID });
                    table.ForeignKey(
                        name: "FK_GROUP_PERMISSION",
                        column: x => x.GroupID,
                        principalTable: "GROUP",
                        principalColumn: "GroupID");
                    table.ForeignKey(
                        name: "FK_PERMISSION_GROUP",
                        column: x => x.PermissionID,
                        principalTable: "PERMISSION",
                        principalColumn: "PermissionID");
                });

            migrationBuilder.CreateTable(
                name: "FLIGHT",
                columns: table => new
                {
                    FlightID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlightName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeparturedDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    RouteID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLIGHT", x => x.FlightID);
                    table.ForeignKey(
                        name: "FK_Flight_R",
                        column: x => x.RouteID,
                        principalTable: "ROUTE",
                        principalColumn: "RouteID");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_U",
                        column: x => x.UserID,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SETTING",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Theme = table.Column<int>(type: "int", nullable: false),
                    NameLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserId", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Setting_User",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IsCreated = table.Column<bool>(type: "bit", nullable: false),
                    IsMember = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => new { x.UserID, x.GroupID });
                    table.ForeignKey(
                        name: "FK_GROUP_USER",
                        column: x => x.GroupID,
                        principalTable: "GROUP",
                        principalColumn: "GroupID");
                    table.ForeignKey(
                        name: "FK_USER_GROUP",
                        column: x => x.UserID,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFlight",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlightId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFlight", x => new { x.UserId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_FLIGHT_USER",
                        column: x => x.FlightId,
                        principalTable: "FLIGHT",
                        principalColumn: "FlightID");
                    table.ForeignKey(
                        name: "FK_USER_FLIGHT",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DOCUMENT",
                columns: table => new
                {
                    DocumentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "(getdate())"),
                    Version = table.Column<decimal>(type: "decimal(18,1)", nullable: false, defaultValueSql: "((1.0))"),
                    Filepath = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PreviousDocumentId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENT", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Document_F",
                        column: x => x.FlightID,
                        principalTable: "FLIGHT",
                        principalColumn: "FlightID");
                    table.ForeignKey(
                        name: "FK_Document_T",
                        column: x => x.CategoryId,
                        principalTable: "CATEGORY",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Document_U",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GROUP_CATEGORY",
                columns: table => new
                {
                    GroupID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_CATEGORY", x => new { x.GroupID, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_Category_GROUP",
                        column: x => x.CategoryId,
                        principalTable: "CATEGORY",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_GROUP_Category",
                        column: x => x.GroupID,
                        principalTable: "GROUP",
                        principalColumn: "GroupID");
                });

            migrationBuilder.CreateTable(
                name: "IsConfirmed",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "(getdate())"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SnapshotSignature = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DocumentId", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_IsConfirm_Document",
                        column: x => x.DocumentId,
                        principalTable: "DOCUMENT",
                        principalColumn: "DocumentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_UserID",
                table: "CATEGORY",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENT_CategoryId",
                table: "DOCUMENT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENT_FlightID",
                table: "DOCUMENT",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENT_UserId",
                table: "DOCUMENT",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHT_RouteID",
                table: "FLIGHT",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_CATEGORY_CategoryId",
                table: "GROUP_CATEGORY",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPermission_PermissionID",
                table: "GroupPermission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "USER",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "USER",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserFlight_FlightId",
                table: "UserFlight",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupID",
                table: "UserGroup",
                column: "GroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GROUP_CATEGORY");

            migrationBuilder.DropTable(
                name: "GroupPermission");

            migrationBuilder.DropTable(
                name: "IsConfirmed");

            migrationBuilder.DropTable(
                name: "SETTING");

            migrationBuilder.DropTable(
                name: "UserFlight");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PERMISSION");

            migrationBuilder.DropTable(
                name: "DOCUMENT");

            migrationBuilder.DropTable(
                name: "GROUP");

            migrationBuilder.DropTable(
                name: "FLIGHT");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "ROUTE");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
