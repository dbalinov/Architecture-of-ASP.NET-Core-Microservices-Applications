using OnlineStore.Identity.Data.Models;

namespace OnlineStore.Identity.Services.Identity
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
