using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocSys.Migrations
{
    public partial class settingfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Filepath",
                table: "DOCUMENT",
                newName: "FilePath");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "SETTING",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fileLogo",
                table: "SETTING",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "DOCUMENT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "DOCUMENT",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "SETTING");

            migrationBuilder.DropColumn(
                name: "fileLogo",
                table: "SETTING");

            migrationBuilder.DropColumn(
                name: "FileData",
                table: "DOCUMENT");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "DOCUMENT",
                newName: "Filepath");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Filepath",
                table: "DOCUMENT",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
