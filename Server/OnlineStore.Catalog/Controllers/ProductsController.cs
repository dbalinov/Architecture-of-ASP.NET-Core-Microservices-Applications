using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Catalog.Models.Products;
using OnlineStore.Catalog.Services.Products;
using OnlineStore.Common.Controllers;

namespace OnlineStore.Catalog.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService productService;
        
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ProductOutputModel>>> Search(
            [FromQuery] ProductsQuery query)
        {
            var products = await this.productService.SearchAsync(query);

            return Ok(products);
        }
    }
}