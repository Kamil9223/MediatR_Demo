using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Dtos
{
    public class ProductRequestDto : ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
