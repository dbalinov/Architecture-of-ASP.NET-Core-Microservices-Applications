using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Common.Infrastructure;
using OnlineStore.JwtAuthentication.Infrastructure;
using OnlineStore.Payment.Data;
using OnlineStore.Payment.Services;

namespace OnlineStore.Payment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase<PaymentDbContext>(this.Configuration)
                .AddJwtTokenAuthentication(this.Configuration)
                .AddScoped<IPayService, PayService>()
                .AddMessaging(this.Configuration)
                .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }

}
