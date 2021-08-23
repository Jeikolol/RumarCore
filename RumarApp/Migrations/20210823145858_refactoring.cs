using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RumarApp.Migrations
{
    public partial class refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Beneficiaries_BeneficiaryId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BeneficiaryId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "BeneficiaryId",
                table: "Loans");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TransactionTypes",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "TransactionTypes",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TransactionTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "TransactionTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "TransactionTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TransactionTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TransactionPayments",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "TransactionPayments",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TransactionPayments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "TransactionPayments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "TransactionPayments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TransactionPayments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Loans",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Loans",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Loans",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Loans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Loans",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Loans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ClientTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "ClientTypes",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ClientTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ClientTypes",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "ClientTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ClientTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Clients",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Clients",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Beneficiaries",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Beneficiaries",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Identification",
                table: "Beneficiaries",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "FisrtName",
                table: "Beneficiaries",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Beneficiaries",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "ClientViewModelId",
                table: "Beneficiaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Beneficiaries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Beneficiaries",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Beneficiaries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Beneficiaries",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedReason",
                table: "Beneficiaries",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Beneficiaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LoanId",
                table: "Beneficiaries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaxTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedReason = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    MyProperty = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_ClientViewModelId",
                table: "Beneficiaries",
                column: "ClientViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_LoanId",
                table: "Beneficiaries",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Clients_ClientViewModelId",
                table: "Beneficiaries",
                column: "ClientViewModelId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Loans_LoanId",
                table: "Beneficiaries",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Clients_ClientViewModelId",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Loans_LoanId",
                table: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "TaxTypes");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_ClientViewModelId",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_LoanId",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TransactionTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TransactionPayments");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "TransactionPayments");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TransactionPayments");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "TransactionPayments");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "TransactionPayments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TransactionPayments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClientTypes");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "ClientTypes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ClientTypes");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ClientTypes");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "ClientTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ClientTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientViewModelId",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "DeletedReason",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "Beneficiaries");

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryId",
                table: "Loans",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Beneficiaries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Beneficiaries",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Identification",
                table: "Beneficiaries",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FisrtName",
                table: "Beneficiaries",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Beneficiaries",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
