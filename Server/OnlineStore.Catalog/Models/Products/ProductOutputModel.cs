using OnlineStore.Catalog.Data.Models;

namespace OnlineStore.Catalog.Models.Products
{
    public class ProductOutputModel : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageBase64 { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
    }
}
