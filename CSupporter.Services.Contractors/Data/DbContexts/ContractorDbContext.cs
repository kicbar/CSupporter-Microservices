using CSupporter.Services.Contractors.Models;
using Microsoft.EntityFrameworkCore;

namespace CSupporter.Services.Contractors.Data.DbContexts
{
    public class ContractorDbContext : DbContext
    {
        public ContractorDbContext(DbContextOptions<ContractorDbContext> options) : base(options)
        {

        }

        public DbSet<Contractor> Contractors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contractor>().HasData(new Contractor
            {
                ContractorId = 1,
                FirstName = "Richard",
                LastName = "Nowak",
                Address = "Warszawa, ul. Przedszkolna 15",
                CompanyName = "GM Prime RN",
                CompanyDetails = "--",
                NIP = "912-111-09-10"
            });
            modelBuilder.Entity<Contractor>().HasData(new Contractor
            {
                ContractorId = 2,
                FirstName = "Adrian",
                LastName = "Kowalski",
                Address = "Gdański, ul. Mariacka 8",
                CompanyName = "FUH Adrian",
                CompanyDetails = "--",
                NIP = "805-111-09-10"
            });
            modelBuilder.Entity<Contractor>().HasData(new Contractor
            {
                ContractorId = 3,
                FirstName = "Roman",
                LastName = "Romanowicz",
                Address = "Wrocław, ul. Żeromskiego 10",
                CompanyName = "KOMFORT",
                CompanyDetails = "--",
                NIP = "712-934-35-23"
            });
        }
    }
}
