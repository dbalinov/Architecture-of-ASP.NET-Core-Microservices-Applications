using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Catalog.Data;
using OnlineStore.Catalog.Data.Models;
using OnlineStore.Catalog.Models.Categories;
using OnlineStore.Common.Services;

namespace OnlineStore.Catalog.Services.Categories
{
    internal class CategoryService : DataService<Category>, ICategoryService
    {
        private readonly IMapper mapper;

        public CategoryService(CatalogDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<IEnumerable<CategoryOutputModel>> GetAllAsync()
            => await this.mapper
                .ProjectTo<CategoryOutputModel>(this.All())
                .ToListAsync();
    }
}
