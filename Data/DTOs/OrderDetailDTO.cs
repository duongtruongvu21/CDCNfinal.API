using CDCNfinal.API.Data.DTOs;

namespace CDCNfinal.API.Data.DTOs
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        
        public ProductDetailDTO Product { get; set; }

        public string CustomerName { get; set; }
        
        public string CustomerAddress { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string StatusOrder { get; set; }
        
        public DateTime OrderAt { get; set; }
    }
}