﻿using CSupporter.Services.Products.Data.DbContexts;
using CSupporter.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSupporter.Services.Products.Repositories
{
    public class WarehouseRepository
    {
        private readonly ProductDbContext _productDbContext;

        public WarehouseRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public bool CreateAmountForProduct(int productId, Warehouse warehouse)
        {
            Product productExist = _productDbContext.Products.Where(product => product.ProductId == productId).FirstOrDefault();
            if (productExist != null)
            {
                warehouse.ProductId = productId;
                _productDbContext.Add(warehouse);
                _productDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Warehouse GetWarehouseForProduct(int productId)
        {
            Warehouse warehouse = _productDbContext.WarehouseAmounts.Where(warehouse => warehouse.ProductId == productId).FirstOrDefault();
            return warehouse;
        }

        public int GetAmountForProduct(int productId) 
        {
            Warehouse warehouse = GetWarehouseForProduct(productId);
            return warehouse.Amount;
        }

        public int ChangeAmountForProduct(int productId, int amountToAdd)
        {
            Warehouse warehouse = GetWarehouseForProduct(productId);
            int newAmount = warehouse.Amount + amountToAdd;

            if (newAmount >= 0)
            {
                warehouse.Amount = newAmount;
                _productDbContext.SaveChanges();
                return newAmount;
            }
            return 0;
        }

        public bool RemoveAmountForProduct(int productId, Warehouse warehouse)
        {
            Product productExist = _productDbContext.Products.Where(product => product.ProductId == productId).FirstOrDefault();
            if (productExist != null)
            {
                warehouse.ProductId = productId;
                _productDbContext.Remove(warehouse);
                _productDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
