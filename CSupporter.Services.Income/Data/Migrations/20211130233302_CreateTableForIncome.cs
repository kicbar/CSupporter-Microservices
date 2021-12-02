using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSupporter.Services.Income.Migrations
{
    public partial class CreateTableForIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeCalculations",
                columns: table => new
                {
                    CalculateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalculateValue = table.Column<double>(type: "float", nullable: false),
                    CalculateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCalculations", x => x.CalculateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeCalculations");
        }
    }
}
