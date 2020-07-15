using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Common.Infrastructure;
using OnlineStore.JwtAuthentication.Infrastructure;
using OnlineStore.Ordering.Data;
using OnlineStore.Ordering.Services;
using System.Reflection;
using AutoMapper;
using OnlineStore.Ordering.Messages;

namespace OnlineStore.Ordering
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase<OrderingDbContext>(this.Configuration)
                .AddJwtTokenAuthentication(this.Configuration)
                .AddHealth(this.Configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddScoped<IOrderService, OrderService>()
                .AddMessaging(this.Configuration, typeof(PaymentCompletedConsumer))
                .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
