using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocSys.Migrations
{
    public partial class FlightDocSysInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });

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
                name: "TypeDo",
                columns: table => new
                {
                    TypeDoID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDo", x => x.TypeDoID);
                });

            migrationBuilder.CreateTable(
                name: "GROUP_DOCUMENT",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_DOCUMENT", x => new { x.GroupID, x.DocumentID });
                    table.ForeignKey(
                        name: "FK_DOCUMENT_G",
                        column: x => x.DocumentID,
                        principalTable: "DOCUMENT",
                        principalColumn: "DocumentID");
                    table.ForeignKey(
                        name: "FK_GROUP_D",
                        column: x => x.GroupID,
                        principalTable: "GROUP",
                        principalColumn: "GroupID");
                });

            migrationBuilder.CreateTable(
                name: "GROUP_PERMISSION",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_PERMISSION", x => new { x.GroupID, x.PermissionID });
                    table.ForeignKey(
                        name: "FK_GROUP",
                        column: x => x.GroupID,
                        principalTable: "GROUP",
                        principalColumn: "GroupID");
                    table.ForeignKey(
                        name: "FK_PERMISSION_G",
                        column: x => x.PermissionID,
                        principalTable: "PERMISSION",
                        principalColumn: "PermissionID");
                });

            migrationBuilder.CreateTable(
                name: "ROLE_PERMISSION",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_PERMISSION", x => new { x.RoleID, x.PermissionID });
                    table.ForeignKey(
                        name: "FK_PERMISSION",
                        column: x => x.PermissionID,
                        principalTable: "PERMISSION",
                        principalColumn: "PermissionID");
                    table.ForeignKey(
                        name: "FK_ROLE",
                        column: x => x.RoleID,
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
                name: "USER_DOCUMENT",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_DOCUMENT", x => new { x.UserID, x.DocumentID });
                    table.ForeignKey(
                        name: "FK_DOCUMENT_U",
                        column: x => x.DocumentID,
                        principalTable: "DOCUMENT",
                        principalColumn: "DocumentID");
                    table.ForeignKey(
                        name: "FK_USER_D",
                        column: x => x.UserID,
                        principalTable: "USER",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "USER_FLIGHT",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FlightID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_FLIGHT", x => new { x.UserID, x.FlightID });
                    table.ForeignKey(
                        name: "FK_FLIGHT",
                        column: x => x.FlightID,
                        principalTable: "FLIGHT",
                        principalColumn: "FlightID");
                    table.ForeignKey(
                        name: "FK_USER",
                        column: x => x.UserID,
                        principalTable: "USER",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "USER_GROUP",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_GROUP", x => new { x.UserID, x.GroupID });
                    table.ForeignKey(
                        name: "FK_GROUP_U",
                        column: x => x.GroupID,
                        principalTable: "GROUP",
                        principalColumn: "GroupID");
                    table.ForeignKey(
                        name: "FK_USER_G",
                        column: x => x.UserID,
                        principalTable: "USER",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_DOCUMENT_DocumentID",
                table: "GROUP_DOCUMENT",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_PERMISSION_PermissionID",
                table: "GROUP_PERMISSION",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_PERMISSION_PermissionID",
                table: "ROLE_PERMISSION",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_RoleID",
                table: "USER",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_DOCUMENT_DocumentID",
                table: "USER_DOCUMENT",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_FLIGHT_FlightID",
                table: "USER_FLIGHT",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_GROUP_GroupID",
                table: "USER_GROUP",
                column: "GroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GROUP_DOCUMENT");

            migrationBuilder.DropTable(
                name: "GROUP_PERMISSION");

            migrationBuilder.DropTable(
                name: "ROLE_PERMISSION");

            migrationBuilder.DropTable(
                name: "ROUTE");

            migrationBuilder.DropTable(
                name: "TypeDo");

            migrationBuilder.DropTable(
                name: "USER_DOCUMENT");

            migrationBuilder.DropTable(
                name: "USER_FLIGHT");

            migrationBuilder.DropTable(
                name: "USER_GROUP");

            migrationBuilder.DropTable(
                name: "PERMISSION");

            migrationBuilder.DropTable(
                name: "DOCUMENT");

            migrationBuilder.DropTable(
                name: "FLIGHT");

            migrationBuilder.DropTable(
                name: "GROUP");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "ROLE");
        }
    }
}
