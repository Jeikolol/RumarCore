using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RumarApp.Migrations
{
    public partial class add_fields_notes_creationdate_loans_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Loans",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Loans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Loans");
        }
    }
}
