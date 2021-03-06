using CSupporter.Services.Products.Models;

namespace CSupporter.Services.Products.Repositories.IRepositories
{
    public interface IWarehouseRepository
    {
        public bool CreateAmountForProduct(int productId, int? amount);
        Warehouse GetWarehouseForProduct(int productId);
        int GetAmountForProduct(int productId);
        public int ChangeAmountForProduct(int productId, int amountToAdd);
        bool RemoveAmountForProduct(int productId, Warehouse warehouse); 
    }
}
