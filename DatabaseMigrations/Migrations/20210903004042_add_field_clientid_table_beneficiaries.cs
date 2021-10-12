using Microsoft.EntityFrameworkCore.Migrations;

namespace RumarApp.Migrations
{
    public partial class add_field_clientid_table_beneficiaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Clients_ClientViewModelId",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_ClientViewModelId",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "ClientViewModelId",
                table: "Beneficiaries");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Beneficiaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_ClientId",
                table: "Beneficiaries",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Clients_ClientId",
                table: "Beneficiaries",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Clients_ClientId",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_ClientId",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Beneficiaries");

            migrationBuilder.AddColumn<int>(
                name: "ClientViewModelId",
                table: "Beneficiaries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_ClientViewModelId",
                table: "Beneficiaries",
                column: "ClientViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Clients_ClientViewModelId",
                table: "Beneficiaries",
                column: "ClientViewModelId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
