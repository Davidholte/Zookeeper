using Digital.Habitat.Api.Domain.Models.Loans;

namespace Digital.Habitat.Api.Domain.Repositories
{
    public interface ILoanRepository
    {
        Loan GetById(LoanId loanId);
    }
}
