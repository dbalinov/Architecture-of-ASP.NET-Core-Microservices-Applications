using System.Threading.Tasks;
using MassTransit;
using OnlineStore.Catalog.Services.Products;
using OnlineStore.Common.Messages.Orders;

namespace OnlineStore.Catalog.Messages
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedMessage>
    {
        private readonly IProductService productService;

        public OrderCreatedConsumer(IProductService productService)
            => this.productService = productService;

        public Task Consume(ConsumeContext<OrderCreatedMessage> context)
            => this.productService.UpdateQuantityAsync(context.Message);
    }
}
