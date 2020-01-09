using Digital.Habitat.Api.Domain.Models.Loans;
using Digital.Habitat.Api.Domain.Repositories;

namespace Digital.Habitat.Api.Data.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        public Loan GetById(LoanId loanId)
        {
            // LoanDto loan = Context.FirstOrDefault(e => e.Guid == loanId.Id);
            // return loan.ToDomain();
            return new Loan(1000.1000010101m);
        }
    }
}
