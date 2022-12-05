namespace CDCNfinal.API.Data.DTOs
{
    public class OrderOverviewDto
    {
        public int Id { get; set; }
        
        public ProductDTO Product { get; set; }

        public string CustomerName { get; set; }
        
        public string CustomerAddress { get; set; }
        
        public string PhoneNumber { get; set; }

        public string Status { get; set; }
        
        public DateTime OrderAt { get; set; }
    }
}