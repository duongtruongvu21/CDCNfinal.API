namespace CDCNfinal.API.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        
        public Product Product { get; set; }

        public string CustomerName { get; set; }
        
        public string CustomerAddress { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public int StatusOrder { get; set; }
        
        public DateTime OrderAt { get; set; }
    }
}