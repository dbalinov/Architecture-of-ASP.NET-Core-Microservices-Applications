using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Catalog.Models.Categories;

namespace OnlineStore.Catalog.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryOutputModel>> GetAllAsync();
    }
}
