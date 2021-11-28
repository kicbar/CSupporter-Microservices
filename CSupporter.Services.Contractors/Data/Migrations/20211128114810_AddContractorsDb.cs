using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSupporter.Services.Contractors.Migrations
{
    public partial class AddContractorsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    ContractorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.ContractorId);
                });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "ContractorId", "Address", "CompanyDetails", "CompanyName", "FirstName", "InsertDate", "LastName", "NIP", "UpdateDate" },
                values: new object[] { 1, "Warszawa, ul. Przedszkolna 15", "--", "GM Prime RN", "Richard", new DateTime(2021, 11, 28, 12, 48, 9, 915, DateTimeKind.Local).AddTicks(121), "Nowak", "912-111-09-10", new DateTime(2021, 11, 28, 12, 48, 9, 918, DateTimeKind.Local).AddTicks(9420) });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "ContractorId", "Address", "CompanyDetails", "CompanyName", "FirstName", "InsertDate", "LastName", "NIP", "UpdateDate" },
                values: new object[] { 2, "Gdański, ul. Mariacka 8", "--", "FUH Adrian", "Adrian", new DateTime(2021, 11, 28, 12, 48, 9, 921, DateTimeKind.Local).AddTicks(3707), "Kowalski", "805-111-09-10", new DateTime(2021, 11, 28, 12, 48, 9, 921, DateTimeKind.Local).AddTicks(3755) });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "ContractorId", "Address", "CompanyDetails", "CompanyName", "FirstName", "InsertDate", "LastName", "NIP", "UpdateDate" },
                values: new object[] { 3, "Wrocław, ul. Żeromskiego 10", "--", "KOMFORT", "Roman", new DateTime(2021, 11, 28, 12, 48, 9, 921, DateTimeKind.Local).AddTicks(4018), "Romanowicz", "712-934-35-23", new DateTime(2021, 11, 28, 12, 48, 9, 921, DateTimeKind.Local).AddTicks(4026) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contractors");
        }
    }
}
