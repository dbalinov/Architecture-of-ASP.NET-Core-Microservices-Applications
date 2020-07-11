using System.Threading.Tasks;
using OnlineStore.Common.Services;
using OnlineStore.Identity.Data.Models;
using OnlineStore.Identity.Models.Identity;

namespace OnlineStore.Identity.Services.Identity
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(CreateUserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}
