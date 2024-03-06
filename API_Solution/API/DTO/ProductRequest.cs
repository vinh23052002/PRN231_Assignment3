namespace API.DTO
{
    public class ProductRequest
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitslnStock { get; set; }
        public int? CategoryId { get; set; }
    }
}
