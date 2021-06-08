using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductCategoryRepository
    {
        Task<ProductCategory> GetProductCategory(int id);
        Task<IEnumerable<ProductCategory>> GetProductCategories();
        void Add(ProductCategory productCategory);
        void SaveChanges();
    }
}
