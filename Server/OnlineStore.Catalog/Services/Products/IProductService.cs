using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Catalog.Data.Models;
using OnlineStore.Catalog.Models.Products;
using OnlineStore.Common.Messages.Orders;

namespace OnlineStore.Catalog.Services.Products
{
    public interface IProductService
    {
        Task<IList<ProductOutputModel>> SearchAsync(ProductsQuery query);
        Task UpdateQuantityAsync(OrderCreatedMessage message);
    }
}
