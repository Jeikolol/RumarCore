using Microsoft.EntityFrameworkCore.Migrations;

namespace RumarApp.Migrations
{
    public partial class add_field_phonenumber_clients_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Clients",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Clients");
        }
    }
}
