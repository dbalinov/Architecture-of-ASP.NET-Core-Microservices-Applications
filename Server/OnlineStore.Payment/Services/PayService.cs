using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using OnlineStore.Common.Messages.Payment;
using OnlineStore.Common.Services;
using OnlineStore.Payment.Data;
using OnlineStore.Payment.Models;

namespace OnlineStore.Payment.Services
{
    internal class PayService : IPayService
    {
        private readonly PaymentDbContext db;
        private readonly IBus publisher;
        private readonly ILogger<PayService> logger;

        public PayService(PaymentDbContext db, IBus publisher, ILogger<PayService> logger)
        {
            this.db = db;
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

                await db.Payments.AddAsync(payment);

                var message = new PaymentCompletedMessage
                {
                    OrderId = payment.OrderId
                };

                await this.publisher.Publish(message);

                await db.SaveChangesAsync();

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
