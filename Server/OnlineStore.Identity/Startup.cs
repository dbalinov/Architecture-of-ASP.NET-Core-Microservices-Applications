using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Common.Infrastructure;
using OnlineStore.Identity.Data;
using OnlineStore.Identity.Infrastructure;
using OnlineStore.Identity.Services.Identity;
using OnlineStore.JwtAuthentication.Infrastructure;

namespace OnlineStore.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase<IdentityDbContext>(this.Configuration)
                .AddJwtTokenAuthentication(this.Configuration)
                .AddUserStorage()
                .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
