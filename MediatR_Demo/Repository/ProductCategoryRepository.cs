using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    internal class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductCategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(ProductCategory productCategory)
        {
            _databaseContext.ProductCategories.Add(productCategory);
            _databaseContext.SaveChanges();
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            return await _databaseContext.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetProductCategory(int id)
        {
            return await _databaseContext.ProductCategories.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
    }
}
