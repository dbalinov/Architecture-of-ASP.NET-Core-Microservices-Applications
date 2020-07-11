using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Common.Controllers;
using OnlineStore.Payment.Models;
using OnlineStore.Payment.Services;

namespace OnlineStore.Payment.Controllers
{
    public class PayController : ApiController
    {
        private readonly IPayService payService;

        public PayController(IPayService payService)
            => this.payService = payService;

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(PayInputModel input)
        {
            var result = await this.payService.PayAsync(input);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }
    }
}
