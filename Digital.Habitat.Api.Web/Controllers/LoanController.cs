using System;
using Digital.Habitat.Api.Application.Services.Loans;
using Digital.Habitat.Api.Domain.Models.Loans;
using Digital.Habitat.Api.Interfaces.Models.Loans;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Digital.Habitat.Api.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : BaseApiController
    {
        public ILoanService LoanService { get; set; }

        public LoanController(
            ILoanService loanService,
            ILogger<BaseApiController> logger
            ) : base(logger)
        {
            LoanService = loanService;
        }

        [HttpGet]
        [Route("{loanIdGuid}")]
        public LoanViewModel Get(Guid loanIdGuid)
        {
            LoanId loanId = new LoanId(loanIdGuid);
            return LoanService.GetById(loanId);
        }
    }
}
