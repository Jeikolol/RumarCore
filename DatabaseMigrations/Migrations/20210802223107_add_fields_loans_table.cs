using Microsoft.EntityFrameworkCore.Migrations;

namespace RumarApp.Migrations
{
    public partial class add_fields_loans_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CapitalToShow",
                table: "Loans",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ClientTypeId",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Clients",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ClientTypeId",
                table: "Loans",
                column: "ClientTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_ClientTypes_ClientTypeId",
                table: "Loans",
                column: "ClientTypeId",
                principalTable: "ClientTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_ClientTypes_ClientTypeId",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "ClientTypes");

            migrationBuilder.DropIndex(
                name: "IX_Loans_ClientTypeId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CapitalToShow",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ClientTypeId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Clients");
        }
    }
}
