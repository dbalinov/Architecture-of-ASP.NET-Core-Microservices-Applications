using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OnlineStore.Common.Services;
using OnlineStore.Ordering.Data;
using OnlineStore.Ordering.Data.Models;
using OnlineStore.Ordering.Models;

namespace OnlineStore.Ordering.Services
{
    internal class OrderService : IOrderService
    {
        private readonly OrderingDbContext db;
        private readonly ILogger<OrderService> logger;

        public OrderService(OrderingDbContext db, ILogger<OrderService> logger)
        {
            this.db = db;
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

                await db.Orders.AddAsync(order);

                await db.SaveChangesAsync();

                return Result<int>.SuccessWith(order.Id);
            }
            catch (Exception e)
            {
                var errorMessage = "Failed to save order";

                this.logger.LogError(e, errorMessage);

                return Result<int>.Failure(new [] { errorMessage });
            }
        }
    }
}
