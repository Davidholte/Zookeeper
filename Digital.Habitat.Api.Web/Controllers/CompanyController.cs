using Digital.Habitat.Api.Interfaces.Models.Companies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Digital.Habitat.Api.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : BaseApiController
    {
        public CompanyController(ILogger<BaseApiController> logger) : base(logger)
        {
        }

        [HttpGet]
        public CompanyViewModel Get()
        {
            return new CompanyViewModel();
        }
    }
}
