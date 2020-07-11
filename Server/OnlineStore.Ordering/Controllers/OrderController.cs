using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Common.Controllers;
using OnlineStore.JwtAuthentication.Services.Identity;
using OnlineStore.Ordering.Models;
using OnlineStore.Ordering.Services;

namespace OnlineStore.Ordering.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService orderService;
        private readonly ICurrentUserService currentUserService;

        public OrderController(IOrderService orderService, ICurrentUserService currentUserService)
        {
            this.orderService = orderService;
            this.currentUserService = currentUserService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateOrderOutputModel>> Create(CreateOrderInputModel input)
        {
            var result = await this.orderService.CreateAsync(input, this.currentUserService.UserId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return new CreateOrderOutputModel(result.Data);
        }
    }
}
