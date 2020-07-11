using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Common.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
