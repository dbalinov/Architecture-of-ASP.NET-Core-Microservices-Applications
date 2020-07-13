using System.Threading.Tasks;
using MassTransit;
using OnlineStore.Common.Messages.Payment;
using OnlineStore.Ordering.Data.Models;
using OnlineStore.Ordering.Services;

namespace OnlineStore.Ordering.Messages
{
    public class PaymentCompletedConsumer : IConsumer<PaymentCompletedMessage>
    {
        private readonly IOrderService orderService;

        public PaymentCompletedConsumer(IOrderService orderService)
            => this.orderService = orderService;

        public Task Consume(ConsumeContext<PaymentCompletedMessage> context)
            => this.orderService.SetStatusAsync(
                context.Message.OrderId, OrderStatus.Paid);
    }
}