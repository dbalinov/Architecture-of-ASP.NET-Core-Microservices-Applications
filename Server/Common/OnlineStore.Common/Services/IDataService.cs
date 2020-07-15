using OnlineStore.Common.Data.Models;
using System.Threading.Tasks;

namespace OnlineStore.Common.Services
{
    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task SaveAsync(TEntity entity, params Message[] messages);
    }
}
