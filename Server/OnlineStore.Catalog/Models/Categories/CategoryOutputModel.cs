using OnlineStore.Catalog.Data.Models;

namespace OnlineStore.Catalog.Models.Categories
{
    public class CategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
