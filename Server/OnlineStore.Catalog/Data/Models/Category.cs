using System.Collections.Generic;

namespace OnlineStore.Catalog.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}