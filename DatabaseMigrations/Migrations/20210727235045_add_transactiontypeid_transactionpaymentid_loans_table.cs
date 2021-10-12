using Microsoft.EntityFrameworkCore.Migrations;

namespace RumarApp.Migrations
{
    public partial class add_transactiontypeid_transactionpaymentid_loans_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionPaymentId",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeId",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_TransactionPaymentId",
                table: "Loans",
                column: "TransactionPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_TransactionTypeId",
                table: "Loans",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_TransactionPayments_TransactionPaymentId",
                table: "Loans",
                column: "TransactionPaymentId",
                principalTable: "TransactionPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_TransactionTypes_TransactionTypeId",
                table: "Loans",
                column: "TransactionTypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_TransactionPayments_TransactionPaymentId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_TransactionTypes_TransactionTypeId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_TransactionPaymentId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_TransactionTypeId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "TransactionPaymentId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "TransactionTypeId",
                table: "Loans");
        }
    }
}
