using Data.Entities;
using Data.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);
        Task<ProductWithCategory> GetProductWithCategory(int id);
        void Add(Product product);
        void SaveChanges();
    }
}
