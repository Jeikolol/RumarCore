using Microsoft.EntityFrameworkCore.Migrations;

namespace RumarApp.Migrations
{
    public partial class alter_field_beneficiaryid_table_loans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Beneficiaries_BeneficiaryId",
                table: "Loans");

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiaryId",
                table: "Loans",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Beneficiaries_BeneficiaryId",
                table: "Loans",
                column: "BeneficiaryId",
                principalTable: "Beneficiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Beneficiaries_BeneficiaryId",
                table: "Loans");

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiaryId",
                table: "Loans",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Beneficiaries_BeneficiaryId",
                table: "Loans",
                column: "BeneficiaryId",
                principalTable: "Beneficiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
