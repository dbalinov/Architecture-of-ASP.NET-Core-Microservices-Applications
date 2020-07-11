using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OnlineStore.Common.Services;
using OnlineStore.Payment.Data;
using OnlineStore.Payment.Models;

namespace OnlineStore.Payment.Services
{
    internal class PayService : IPayService
    {
        private readonly PaymentDbContext db;
        private readonly ILogger<PayService> logger;

        public PayService(PaymentDbContext db, ILogger<PayService> logger)
        {
            this.db = db;
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
