using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Catalog.Data;
using OnlineStore.Catalog.Models.Products;

namespace OnlineStore.Catalog.Services.Products
{
    internal class ProductService : IProductService
    {
        private readonly CatalogDbContext db;
        private readonly IMapper mapper;

        public ProductService(CatalogDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IList<ProductOutputModel>> SearchAsync(ProductsQuery query)
            => await this.mapper
                .ProjectTo<ProductOutputModel>(this.db.Products
                        .AsQueryable()
                        .Where(p => !query.CategoryId.HasValue ||
                                    p.CategoryId == query.CategoryId.Value)
                )
                .ToListAsync();
    }
}
