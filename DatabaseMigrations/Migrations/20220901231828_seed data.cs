using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseMigrations.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedById", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Email", "FirstName", "Identification", "IsDeleted", "LastName", "MobileNumber", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 1, "", 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7028), null, null, null, "admin@admin.com", "Administrador", "40228341968", false, "", null, "1000:o/aziZjsVx7sr4RzrtPHNs2AkP5LGuhH:txBYU1u3kkEktiP64gKan99vXohED85c", "8298879669", "admin" });

            migrationBuilder.InsertData(
                table: "ClientTypes",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7216), null, null, null, "CLIENTE RECURRENTE", false, "RECURRENTE" },
                    { 2, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7217), null, null, null, "CLIENTE RECOMENDADO", false, "RECOMENDADO" },
                    { 3, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7218), null, null, null, "CLIENTE NUEVO", false, "NUEVO" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedById", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "RD", 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7177), null, null, null, "REPUBLICA DOMINICANA", false },
                    { 2, "USA", 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7178), null, null, null, "ESTADOS UNIDOS", false },
                    { 3, "ESP", 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7179), null, null, null, "ESPAÑA", false },
                    { 4, "UK", 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7180), null, null, null, "REINO UNIDO", false }
                });

            migrationBuilder.InsertData(
                table: "RelationshipTypes",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7156), null, null, null, "RELACION FAMILIAR", false, "FAMILIAR" },
                    { 2, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7159), null, null, null, "RELACIONADA", false, "RELACIONADO" },
                    { 3, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7160), null, null, null, "RELACION COMERCIAL", false, "COMERCIAL" }
                });

            migrationBuilder.InsertData(
                table: "TaxTypes",
                columns: new[] { "Id", "Code", "CreatedById", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "IsDeleted", "Name", "Percentage" },
                values: new object[,]
                {
                    { 1, "01", 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7195), null, null, null, false, "0%", 0.0m },
                    { 2, "02", 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7196), null, null, null, false, "18%", 0.18m },
                    { 3, "03", 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7197), null, null, null, false, "25%", 0.25m },
                    { 4, "04", 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7198), null, null, null, false, "50%", 0.50m }
                });

            migrationBuilder.InsertData(
                table: "TransactionPayments",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7249), null, null, null, "PAGO DIARIO", false, "DIARIO" },
                    { 2, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7250), null, null, null, "PAGO QUINCENAL", false, "QUINCENAL" },
                    { 3, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7251), null, null, null, "PAGO MENSUAL", false, "MENSUAL" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "DeletedBy", "DeletedOn", "DeletedReason", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7232), null, null, null, "PAGO EN EFECTIVO", false, "EFECTIVO" },
                    { 2, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7233), null, null, null, "PAGO EN TRANSFERENCIA", false, "TRANSFERENCIA" },
                    { 3, 1, new DateTime(2022, 9, 1, 23, 18, 28, 472, DateTimeKind.Utc).AddTicks(7234), null, null, null, "PAGO EN CHEQUE", false, "CHEQUE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RelationshipTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaxTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaxTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaxTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TransactionPayments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransactionPayments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransactionPayments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
