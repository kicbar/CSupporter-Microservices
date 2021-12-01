using CSupporter.Services.Income.Models;

namespace CSupporter.Services.Income.Repositories.IRepositories
{
    public interface IIncomeRepository
    {
        void CreateIncomeCalculation(IncomeCalculation incomeCalculation);
    }
}
