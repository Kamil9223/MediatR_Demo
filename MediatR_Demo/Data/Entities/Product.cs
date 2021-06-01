using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
