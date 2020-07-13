using System.Threading.Tasks;
using OnlineStore.Common.Services;
using OnlineStore.Ordering.Data.Models;
using OnlineStore.Ordering.Models;

namespace OnlineStore.Ordering.Services
{
    public interface IOrderService
    {
        Task<Result<int>> CreateAsync(CreateOrderInputModel input, string userId);
        Task SetStatusAsync(int orderId, OrderStatus paid);
    }
}
