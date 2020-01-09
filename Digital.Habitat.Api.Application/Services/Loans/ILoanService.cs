using Digital.Habitat.Api.Domain.Models.Loans;
using Digital.Habitat.Api.Interfaces.Models.Loans;

namespace Digital.Habitat.Api.Application.Services.Loans
{
    public interface ILoanService
    {
        LoanViewModel GetById(LoanId loanId);
    }
}
