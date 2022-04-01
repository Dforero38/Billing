namespace Billing.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int IdMark { get; set; }
        public string NameMark { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
