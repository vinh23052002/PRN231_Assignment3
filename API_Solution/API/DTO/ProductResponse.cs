namespace API.DTO
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitslnStock { get; set; }
        public int? CategoryId { get; set; }
    }
}
