using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocSys.Migrations
{
    public partial class DBinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GROUP",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    PermissionID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSION", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "ROUTE",
                columns: table => new
                {
                    RouteID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PointOFLoading = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PointOFUnloading = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROUTE", x => x.RouteID);
                });

            migrationBuilder.CreateTable(
                name: "GroupPermission",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false),
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
                name: "RolePermission",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionID });
                    table.ForeignKey(
                        name: "FK_PERMISSION_ROLE",
                        column: x => x.PermissionID,
                        principalTable: "PERMISSION",
                        principalColumn: "PermissionID");
                    table.ForeignKey(
                        name: "FK_ROLE_PERMISSION",
                        column: x => x.RoleId,
                        principalTable: "ROLE",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberPhone = table.Column<int>(type: "int", nullable: true),
                    StatusCode = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_USER_ROLE",
                        column: x => x.RoleID,
                        principalTable: "ROLE",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "FLIGHT",
                columns: table => new
                {
                    FlightID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RouteID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
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
                name: "DOCUMENT_TYPE",
                columns: table => new
                {
                    Document_TypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENT_TYPE", x => x.Document_TypeId);
                    table.ForeignKey(
                        name: "FK_Document_Type_U",
                        column: x => x.UserID,
                        principalTable: "USER",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
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
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserFlight",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "DOCUMENT",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Version = table.Column<decimal>(type: "decimal(18,1)", nullable: false, defaultValueSql: "((1.0))"),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    FlightID = table.Column<int>(type: "int", nullable: false),
                    TypeDoID = table.Column<int>(type: "int", nullable: false)
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
                        column: x => x.TypeDoID,
                        principalTable: "DOCUMENT_TYPE",
                        principalColumn: "Document_TypeId");
                });

            migrationBuilder.CreateTable(
                name: "GroupDocumenttype",
                columns: table => new
                {
                    Document_TypeId = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupDocumenttype", x => new { x.GroupID, x.Document_TypeId });
                    table.ForeignKey(
                        name: "FK_DOCUMENT_TYPE_GROUP",
                        column: x => x.Document_TypeId,
                        principalTable: "DOCUMENT_TYPE",
                        principalColumn: "Document_TypeId");
                    table.ForeignKey(
                        name: "FK_GROUP_DOCUMENT_TYPE",
                        column: x => x.GroupID,
                        principalTable: "GROUP",
                        principalColumn: "GroupID");
                });

            migrationBuilder.CreateTable(
                name: "UserDocument",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDocument", x => new { x.UserId, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_DOCUMENT_USER",
                        column: x => x.DocumentId,
                        principalTable: "DOCUMENT",
                        principalColumn: "DocumentID");
                    table.ForeignKey(
                        name: "FK_USER_DOCUMENT",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENT_FlightID",
                table: "DOCUMENT",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENT_TypeDoID",
                table: "DOCUMENT",
                column: "TypeDoID");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENT_TYPE_UserID",
                table: "DOCUMENT_TYPE",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHT_RouteID",
                table: "FLIGHT",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupDocumenttype_Document_TypeId",
                table: "GroupDocumenttype",
                column: "Document_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPermission_PermissionID",
                table: "GroupPermission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionID",
                table: "RolePermission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_RoleID",
                table: "USER",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserDocument_DocumentId",
                table: "UserDocument",
                column: "DocumentId");

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
                name: "GroupDocumenttype");

            migrationBuilder.DropTable(
                name: "GroupPermission");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "UserDocument");

            migrationBuilder.DropTable(
                name: "UserFlight");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "PERMISSION");

            migrationBuilder.DropTable(
                name: "DOCUMENT");

            migrationBuilder.DropTable(
                name: "GROUP");

            migrationBuilder.DropTable(
                name: "FLIGHT");

            migrationBuilder.DropTable(
                name: "DOCUMENT_TYPE");

            migrationBuilder.DropTable(
                name: "ROUTE");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "ROLE");
        }
    }
}
