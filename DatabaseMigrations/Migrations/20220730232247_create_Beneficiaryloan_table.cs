using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseMigrations.Migrations
{
    public partial class create_Beneficiaryloan_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeneficiaryLoans",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryLoans", x => new { x.BeneficiaryId, x.LoanId });
                    table.ForeignKey(
                        name: "FK_BeneficiaryLoans_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BeneficiaryLoans_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryLoans_LoanId",
                table: "BeneficiaryLoans",
                column: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeneficiaryLoans");

            migrationBuilder.CreateTable(
                name: "BeneficiaryLoan",
                columns: table => new
                {
                    BeneficiariesId = table.Column<int>(type: "int", nullable: true),
                    LoansId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BeneficiaryLoan_Beneficiaries_BeneficiariesId",
                        column: x => x.BeneficiariesId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryLoan_Loans_LoansId",
                        column: x => x.LoansId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(359), null, null, null, "CLIENTE RECURRENTE", false, "RECURRENTE" },
                    { 2, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(363), null, null, null, "CLIENTE RECOMENDADO", false, "RECOMENDADO" },
                    { 3, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(364), null, null, null, "CLIENTE NUEVO", false, "NUEVO" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "RD", "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(8283), null, null, null, "REPUBLICA DOMINICANA", false },
                    { 2, "USA", "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(8285), null, null, null, "ESTADOS UNIDOS", false },
                    { 3, "ESP", "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(8287), null, null, null, "ESPAÑA", false },
                    { 4, "UK", "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(8288), null, null, null, "REINO UNIDO", false }
                });

            migrationBuilder.InsertData(
                table: "RelationshipTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(7405), null, null, null, "RELACION FAMILIAR", false, "FAMILIAR" },
                    { 2, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(7413), null, null, null, "RELACIONADA", false, "RELACIONADO" },
                    { 3, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(7415), null, null, null, "RELACION COMERCIAL", false, "COMERCIAL" }
                });

            migrationBuilder.InsertData(
                table: "TaxTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "IsDeleted", "Name", "Percentage" },
                values: new object[,]
                {
                    { 4, "04", "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(9448), null, null, null, false, "50%", 0.50m },
                    { 3, "03", "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(9447), null, null, null, false, "25%", 0.25m },
                    { 1, "01", "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(9441), null, null, null, false, "0%", 0.0m },
                    { 2, "02", "admin", new DateTime(2022, 6, 25, 2, 14, 13, 344, DateTimeKind.Utc).AddTicks(9446), null, null, null, false, "18%", 0.18m }
                });

            migrationBuilder.InsertData(
                table: "TransactionPayments",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1927), null, null, null, "PAGO DIARIO", false, "DIARIO" },
                    { 2, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1930), null, null, null, "PAGO QUINCENAL", false, "QUINCENAL" },
                    { 3, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1932), null, null, null, "PAGO MENSUAL", false, "MENSUAL" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 3, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1157), null, null, null, "PAGO EN CHEQUE", false, "CHEQUE" },
                    { 1, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1152), null, null, null, "PAGO EN EFECTIVO", false, "EFECTIVO" },
                    { 2, "admin", new DateTime(2022, 6, 25, 2, 14, 13, 345, DateTimeKind.Utc).AddTicks(1155), null, null, null, "PAGO EN TRANSFERENCIA", false, "TRANSFERENCIA" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Email", "FirstName", "Identification", "IsDeleted", "LastName", "MobileNumber", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 1, "", "admin", new DateTime(2022, 6, 25, 2, 14, 13, 343, DateTimeKind.Utc).AddTicks(8743), null, null, null, "admin@admin.com", "Administrador", "40228341968", false, "", null, "1000:o/aziZjsVx7sr4RzrtPHNs2AkP5LGuhH:txBYU1u3kkEktiP64gKan99vXohED85c", "8298879669", "admin" });
        }
    }
}
