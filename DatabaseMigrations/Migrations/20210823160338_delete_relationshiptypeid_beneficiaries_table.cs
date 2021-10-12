using Microsoft.EntityFrameworkCore.Migrations;

namespace RumarApp.Migrations
{
    public partial class delete_relationshiptypeid_beneficiaries_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_RelationshipTypes_RelationshipTypeId",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_RelationshipTypeId",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "RelationshipTypeId",
                table: "Beneficiaries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelationshipTypeId",
                table: "Beneficiaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_RelationshipTypeId",
                table: "Beneficiaries",
                column: "RelationshipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_RelationshipTypes_RelationshipTypeId",
                table: "Beneficiaries",
                column: "RelationshipTypeId",
                principalTable: "RelationshipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
