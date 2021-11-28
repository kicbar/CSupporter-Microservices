using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSupporter.Services.Factures.Migrations
{
    public partial class AddFacturesDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    FactureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactureNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    ContractorId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.FactureId);
                });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "FactureId", "ContractorId", "FactureDate", "FactureNo", "InsertDate", "UpdateDate", "Value" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 28, 21, 15, 37, 946, DateTimeKind.Local).AddTicks(5739), "FV11/11/2021", new DateTime(2021, 11, 28, 21, 15, 37, 954, DateTimeKind.Local).AddTicks(8120), new DateTime(2021, 11, 28, 21, 15, 37, 954, DateTimeKind.Local).AddTicks(8178), 200.99000000000001 });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "FactureId", "ContractorId", "FactureDate", "FactureNo", "InsertDate", "UpdateDate", "Value" },
                values: new object[] { 2, 1, new DateTime(2021, 11, 28, 21, 15, 37, 958, DateTimeKind.Local).AddTicks(7729), "FV12/11/2021", new DateTime(2021, 11, 28, 21, 15, 37, 958, DateTimeKind.Local).AddTicks(7786), new DateTime(2021, 11, 28, 21, 15, 37, 958, DateTimeKind.Local).AddTicks(7792), 99.989999999999995 });

            migrationBuilder.InsertData(
                table: "Factures",
                columns: new[] { "FactureId", "ContractorId", "FactureDate", "FactureNo", "InsertDate", "UpdateDate", "Value" },
                values: new object[] { 3, 1, new DateTime(2021, 11, 28, 21, 15, 37, 958, DateTimeKind.Local).AddTicks(7971), "FV13/11/2021", new DateTime(2021, 11, 28, 21, 15, 37, 958, DateTimeKind.Local).AddTicks(7979), new DateTime(2021, 11, 28, 21, 15, 37, 958, DateTimeKind.Local).AddTicks(7983), 22.989999999999998 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factures");
        }
    }
}
