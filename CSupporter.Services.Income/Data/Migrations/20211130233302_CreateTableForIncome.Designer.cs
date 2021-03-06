// <auto-generated />
using System;
using CSupporter.Services.Income.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSupporter.Services.Income.Migrations
{
    [DbContext(typeof(IncomeDbContext))]
    [Migration("20211130233302_CreateTableForIncome")]
    partial class CreateTableForIncome
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CSupporter.Services.Income.Models.IncomeCalculation", b =>
                {
                    b.Property<int>("CalculateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CalculateDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("CalculateValue")
                        .HasColumnType("float");

                    b.HasKey("CalculateId");

                    b.ToTable("IncomeCalculations");
                });
#pragma warning restore 612, 618
        }
    }
}
