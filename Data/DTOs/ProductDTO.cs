using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDCNfinal.API.Data.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        
        public string ProductName { get; set; }

        public string BrandName { get; set; }
        
        public string Decription { get; set; }
        
        public decimal Price { get; set; }
    }
}