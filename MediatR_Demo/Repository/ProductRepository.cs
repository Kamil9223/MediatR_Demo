using Data;
using Data.Entities;
using Data.models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    internal class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _databaseContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductWithCategory> GetProductWithCategory(int id)
        {
            return await _databaseContext.Products
                .Select(x => new ProductWithCategory
                {
                    ProductId = x.Id,
                    ProductName = x.Name,
                    CategoryName = x.ProductCategory.CategoryName
                })
                .SingleOrDefaultAsync();
        }

        public void Add(Product product)
        {
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
    }
}
