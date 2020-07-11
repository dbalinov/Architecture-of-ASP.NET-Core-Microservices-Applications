using System.Threading.Tasks;
using OnlineStore.Common.Services;
using OnlineStore.Payment.Models;

namespace OnlineStore.Payment.Services
{
    public interface IPayService
    {
        Task<Result> PayAsync(PayInputModel input);
    }
}
