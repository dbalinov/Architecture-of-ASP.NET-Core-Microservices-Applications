using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Catalog.Models.Categories;
using OnlineStore.Catalog.Services.Categories;
using OnlineStore.Common.Controllers;

namespace OnlineStore.Catalog.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
            => this.categoryService = categoryService;

        [HttpGet]
        public async Task<ActionResult<IList<CategoryOutputModel>>> GetAll()
        {
            var categories = await this.categoryService.GetAllAsync();

            return Ok(categories);
        }
    }
}
