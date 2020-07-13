using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using GreenPipes;
using MassTransit;
using CarRentalSystem.Infrastructure;

namespace OnlineStore.Common.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase<TDbContext>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TDbContext : DbContext
            => services
                .AddScoped<DbContext, TDbContext>()
                .AddDbContext<TDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static IServiceCollection AddMessaging(
            this IServiceCollection services,
            IConfiguration configuration,
            params Type[] consumers)
        {
            services
                .AddMassTransit(mt =>
                {
                    consumers.ForEach(consumer => mt.AddConsumer(consumer));

                    mt.AddBus(context => Bus.Factory.CreateUsingRabbitMq(rmq =>
                    {
                        // TODO: Extract to configuration
                        rmq.Host("localhost");

                        rmq.UseHealthCheck(context);

                        consumers.ForEach(consumer => rmq.ReceiveEndpoint(consumer.FullName, endpoint =>
                        {
                            endpoint.PrefetchCount = 6;
                            endpoint.UseMessageRetry(retry => retry.Interval(10, 1000));

                            endpoint.ConfigureConsumer(context, consumer);
                        }));
                    }));
                })
                .AddMassTransitHostedService();

            return services;
        }
    }
}