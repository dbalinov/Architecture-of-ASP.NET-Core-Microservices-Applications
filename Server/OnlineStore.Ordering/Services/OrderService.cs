using System;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using OnlineStore.Common.Data.Models;
using OnlineStore.Common.Messages.Orders;
using OnlineStore.Common.Services;
using OnlineStore.Ordering.Data;
using OnlineStore.Ordering.Data.Models;
using OnlineStore.Ordering.Models;

namespace OnlineStore.Ordering.Services
{
    internal class OrderService : DataService<Order>, IOrderService
    {
        private readonly IBus publisher;
        private readonly ILogger<OrderService> logger;

        public OrderService(OrderingDbContext db, IBus publisher, ILogger<OrderService> logger)
            : base(db)
        {
            this.publisher = publisher;
            this.logger = logger;
        }

        public async Task<Result<int>> CreateAsync(CreateOrderInputModel input, string userId)
        {
            try
            {
                var orderLines = input.OrderLines
                    .Select(x => new OrderLine
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity
                    })
                    .ToList();

                var order = new Order
                {
                    UserId = userId,
                    OrderLines = orderLines,
                    PhoneNumber = input.PhoneNumber,
                    Address = input.Address,
                    Status = OrderStatus.New
                };

                var messageData = new OrderCreatedMessage
                {
                    Products = orderLines.Select(ol => new OrderCreatedProduct
                    {
                        ProductId = ol.ProductId,
                        Quantity = ol.Quantity
                    }).ToList()
                };

                var message = new Message(messageData);

                await this.SaveAsync(order, message);

                await this.publisher.Publish(messageData);

                await this.MarkMessageAsPublished(message.Id);

                return Result<int>.SuccessWith(order.Id);
            }
            catch (Exception e)
            {
                var errorMessage = "Failed to save order";

                this.logger.LogError(e, errorMessage);

                return Result<int>.Failure(new [] { errorMessage });
            }
        }

        public async Task SetStatusAsync(int orderId, OrderStatus status)
        {
            var order = await this.Data.FindAsync<Order>(orderId);
            
            order.Status = status;

            await this.Data.SaveChangesAsync();
        }
    }
}
