using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseMigrations.Migrations
{
    public partial class Agregarfkcreatedbyidtodaslasentidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeneficiaryClient");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TransactionPayments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaxTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RelationshipTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClientTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BeneficiaryLoans");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Beneficiaries");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "TransactionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "TransactionPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "TaxTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "RelationshipTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RemainingPayments",
                table: "Loans",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Quote",
                table: "Loans",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CapitalToShow",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Capital",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "ClientTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "BeneficiaryLoans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Beneficiaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTypes_CreatedById",
                table: "TransactionTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionPayments_CreatedById",
                table: "TransactionPayments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TaxTypes_CreatedById",
                table: "TaxTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RelationshipTypes_CreatedById",
                table: "RelationshipTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CreatedById",
                table: "Loans",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedById",
                table: "Countries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTypes_CreatedById",
                table: "ClientTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatedById",
                table: "Clients",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryLoans_CreatedById",
                table: "BeneficiaryLoans",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_CreatedById",
                table: "Beneficiaries",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Users_CreatedById",
                table: "Beneficiaries",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryLoans_Users_CreatedById",
                table: "BeneficiaryLoans",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CreatedById",
                table: "Clients",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTypes_Users_CreatedById",
                table: "ClientTypes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Users_CreatedById",
                table: "Countries",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_CreatedById",
                table: "Loans",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationshipTypes_Users_CreatedById",
                table: "RelationshipTypes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxTypes_Users_CreatedById",
                table: "TaxTypes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionPayments_Users_CreatedById",
                table: "TransactionPayments",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionTypes_Users_CreatedById",
                table: "TransactionTypes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatedById",
                table: "Users",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Users_CreatedById",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryLoans_Users_CreatedById",
                table: "BeneficiaryLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CreatedById",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTypes_Users_CreatedById",
                table: "ClientTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Users_CreatedById",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_CreatedById",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationshipTypes_Users_CreatedById",
                table: "RelationshipTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxTypes_Users_CreatedById",
                table: "TaxTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionPayments_Users_CreatedById",
                table: "TransactionPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionTypes_Users_CreatedById",
                table: "TransactionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreatedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TransactionTypes_CreatedById",
                table: "TransactionTypes");

            migrationBuilder.DropIndex(
                name: "IX_TransactionPayments_CreatedById",
                table: "TransactionPayments");

            migrationBuilder.DropIndex(
                name: "IX_TaxTypes_CreatedById",
                table: "TaxTypes");

            migrationBuilder.DropIndex(
                name: "IX_RelationshipTypes_CreatedById",
                table: "RelationshipTypes");

            migrationBuilder.DropIndex(
                name: "IX_Loans_CreatedById",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CreatedById",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_ClientTypes_CreatedById",
                table: "ClientTypes");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatedById",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryLoans_CreatedById",
                table: "BeneficiaryLoans");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_CreatedById",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "TransactionPayments");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "TaxTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "RelationshipTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ClientTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "BeneficiaryLoans");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Beneficiaries");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TransactionTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TransactionPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TaxTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RelationshipTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RemainingPayments",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quote",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "CapitalToShow",
                table: "Loans",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<long>(
                name: "Capital",
                table: "Loans",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ClientTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BeneficiaryLoans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Beneficiaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BeneficiaryClient",
                columns: table => new
                {
                    BeneficiariesId = table.Column<int>(type: "int", nullable: true),
                    ClientsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BeneficiaryClient_Beneficiaries_BeneficiariesId",
                        column: x => x.BeneficiariesId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BeneficiaryClient_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });
        }
    }
}
