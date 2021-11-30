using CSupporter.Services.Income.Models;
using Microsoft.EntityFrameworkCore;

namespace CSupporter.Services.Income.Data.DbContexts
{
    public class IncomeDbContext : DbContext
    {
        public IncomeDbContext(DbContextOptions<IncomeDbContext> options) : base(options)
        {

        }

        public DbSet<IncomeCalculation> IncomeCalculations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
