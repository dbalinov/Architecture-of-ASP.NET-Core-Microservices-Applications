using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Catalog.Data;
using OnlineStore.Catalog.Infrastructure;
using OnlineStore.Common.Infrastructure;
using OnlineStore.JwtAuthentication.Infrastructure;
using System.Reflection;
using OnlineStore.Catalog.Services;
using OnlineStore.Catalog.Services.Categories;
using OnlineStore.Catalog.Services.Products;
using AutoMapper;

namespace OnlineStore.Catalog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase<CatalogDbContext>(this.Configuration)
                .AddJwtTokenAuthentication(this.Configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IProductService, ProductService>()
                .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize()
                .SeedData();
    }
}
