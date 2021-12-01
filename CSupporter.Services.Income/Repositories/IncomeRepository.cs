using CSupporter.Services.Income.Data.DbContexts;
using CSupporter.Services.Income.Models;
using CSupporter.Services.Income.Repositories.IRepositories;
using System;

namespace CSupporter.Services.Income.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly IncomeDbContext _incomeDbContext;

        public IncomeRepository(IncomeDbContext incomeDbContext)
        {
            _incomeDbContext = incomeDbContext;
        }

        public void CreateIncomeCalculation(IncomeCalculation incomeCalculation)
        {
            try
            {
                _incomeDbContext.Add(incomeCalculation);
                _incomeDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
