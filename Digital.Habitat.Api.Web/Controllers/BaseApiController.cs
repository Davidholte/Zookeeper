using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Digital.Habitat.Api.Web.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected ILogger<BaseApiController> Logger { get; set; }

        public BaseApiController(ILogger<BaseApiController> logger)
        {
            Logger = logger;
        }
    }
}
