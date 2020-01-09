using Digital.Habitat.Api.Domain.Models.Loans;
using Digital.Habitat.Api.Domain.Repositories.UnitOfWorks;
using Digital.Habitat.Api.Interfaces.Models.Loans;
using Microsoft.Extensions.Logging;

namespace Digital.Habitat.Api.Application.Services.Loans
{
    public class LoanService : BaseService, ILoanService
    {
        public LoanService(IUnitOfWork unitOfWork, ILogger<BaseService> logger) : base(unitOfWork, logger)
        {
        }

        public LoanViewModel GetById(LoanId loanId)
        {
            var loan = UnitOfWork.LoanRepository.GetById(loanId);
            return LoanViewModel.FromDomain(loan);
        }
    }
}
