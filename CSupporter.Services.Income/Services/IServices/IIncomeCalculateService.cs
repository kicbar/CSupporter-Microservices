using System.Threading.Tasks;

namespace CSupporter.Services.Income.Services.IServices
{
    public interface IIncomeCalculateService
    {
        Task<double> CalculateExecutor();
    }
}
