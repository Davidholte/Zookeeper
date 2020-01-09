using Digital.Habitat.Api.Domain.Models.Loans;

namespace Digital.Habitat.Api.Interfaces.Models.Loans
{
    public class LoanViewModel
    {
        public decimal Amount { get; }

        private LoanViewModel(decimal amount)
        {
            Amount = amount;
        }
        
        public static LoanViewModel FromDomain(Loan loan)
        {
            return new LoanViewModel(loan.Amount);
        }
    }
}
