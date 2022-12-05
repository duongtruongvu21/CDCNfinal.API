using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDCNfinal.API.Data.DTOs
{
    public class OrderDTO
    {   
        public string CustomerName { get; set; }
        
        public string CustomerAddress { get; set; }
        
        public string phoneNumber { get; set; }
        
        public int ProductId { get; set; }
    }
}