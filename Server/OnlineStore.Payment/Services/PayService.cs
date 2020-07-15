using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using OnlineStore.Common.Data.Models;
using OnlineStore.Common.Messages.Payment;
using OnlineStore.Common.Services;
using OnlineStore.Payment.Data;
using OnlineStore.Payment.Models;

namespace OnlineStore.Payment.Services
{
    internal class PayService : DataService<Data.Models.Payment>, IPayService
    {
        private readonly IBus publisher;
        private readonly ILogger<PayService> logger;

        public PayService(PaymentDbContext db, IBus publisher, ILogger<PayService> logger)
            : base(db)
        {
            this.publisher = publisher;
            this.logger = logger;
        }

        public async Task<Result> PayAsync(PayInputModel input)
        {
            try
            {
                var payment = new Data.Models.Payment
                {
                    OrderId = input.OrderId,
                    TotalPrice = input.TotalPrice
                };

                var messageData = new PaymentCompletedMessage
                {
                    OrderId = payment.OrderId
                };

                var message = new Message(messageData);

                await this.SaveAsync(payment, message);

                await this.publisher.Publish(messageData);

                await this.MarkMessageAsPublished(message.Id);

                return Result.Success;
            }
            catch (Exception e)
            {
                var errorMessage = "Failed to save order";

                this.logger.LogError(e, errorMessage);

                return Result.Failure(new[] { errorMessage });
            }
        }
    }
}
