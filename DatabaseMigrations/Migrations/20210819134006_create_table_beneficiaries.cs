using Microsoft.EntityFrameworkCore.Migrations;

namespace RumarApp.Migrations
{
    public partial class create_table_beneficiaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryId",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FisrtName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    Identification = table.Column<string>(maxLength: 12, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BeneficiaryId",
                table: "Loans",
                column: "BeneficiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Beneficiaries_BeneficiaryId",
                table: "Loans",
                column: "BeneficiaryId",
                principalTable: "Beneficiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Beneficiaries_BeneficiaryId",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BeneficiaryId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "BeneficiaryId",
                table: "Loans");
        }
    }
}
