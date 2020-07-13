using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineStore.Catalog.Data;
using OnlineStore.Catalog.Models.Products;
using OnlineStore.Common.Messages.Orders;

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

        public async Task UpdateQuantityAsync(OrderCreatedMessage message)
        {
            var productIds = message.Products.Select(x => x.ProductId);

            var products = await this.db.Products
                .Where(product => productIds.Contains(product.Id))
                .ToListAsync();

            foreach (var product in products)
            {
                var orderCreatedProduct = message.Products.FirstOrDefault(x => x.ProductId == product.Id);

                if (orderCreatedProduct != null)
                {
                    product.Quantity -= product.Quantity;
                }
            }

            await this.db.SaveChangesAsync();
        }
    }
}
