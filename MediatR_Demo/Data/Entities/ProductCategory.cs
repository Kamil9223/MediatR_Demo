using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
