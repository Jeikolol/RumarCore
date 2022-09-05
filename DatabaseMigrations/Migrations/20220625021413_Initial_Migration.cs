using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseMigrations.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capital = table.Column<long>(type: "bigint", nullable: false),
                    CapitalToShow = table.Column<long>(type: "bigint", nullable: false),
                    Quote = table.Column<int>(type: "int", nullable: false),
                    RemainingPayments = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    TransactionPaymentId = table.Column<int>(type: "int", nullable: false),
                    ClientTypeId = table.Column<int>(type: "int", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    IsFullPaid = table.Column<bool>(type: "bit", nullable: false),
                    TaxTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_ClientTypes_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "ClientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_TaxTypes_TaxTypeId",
                        column: x => x.TaxTypeId,
                        principalTable: "TaxTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_TransactionPayments_TransactionPaymentId",
                        column: x => x.TransactionPaymentId,
                        principalTable: "TransactionPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
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

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_CountryId",
                table: "Beneficiaries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CountryId",
                table: "Clients",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ClientId",
                table: "Loans",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ClientTypeId",
                table: "Loans",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_TaxTypeId",
                table: "Loans",
                column: "TaxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_TransactionPaymentId",
                table: "Loans",
                column: "TransactionPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_TransactionTypeId",
                table: "Loans",
                column: "TransactionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelationshipTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ClientTypes");

            migrationBuilder.DropTable(
                name: "TaxTypes");

            migrationBuilder.DropTable(
                name: "TransactionPayments");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
