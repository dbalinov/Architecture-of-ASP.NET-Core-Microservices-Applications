namespace OnlineStore.Catalog.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageBase64 { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
    }
}
