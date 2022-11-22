using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDCNfinal.API.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(256)]
        public string ProductName { get; set; }
        
        [MaxLength(256)]
        public string BrandName { get; set; }
        
        public string Decription { get; set; }
        
        public decimal Price { get; set; }
    }
}