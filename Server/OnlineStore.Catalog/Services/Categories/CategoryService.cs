using OnlineStore.Catalog.Models.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Catalog.Data;

namespace OnlineStore.Catalog.Services.Categories
{
    internal class CategoryService : ICategoryService
    {
        private readonly CatalogDbContext db;
        private readonly IMapper mapper;

        public CategoryService(CatalogDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoryOutputModel>> GetAllAsync()
            => await this.mapper
                .ProjectTo<CategoryOutputModel>(this.db.Categories.AsQueryable())
                .ToListAsync();
    }
}
