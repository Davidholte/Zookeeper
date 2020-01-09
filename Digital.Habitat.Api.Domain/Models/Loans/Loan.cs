namespace Digital.Habitat.Api.Domain.Models.Loans
{
    public class Loan
    {
        public decimal Amount { get; set; }
        //public Money Amount { get; set; }

        public Loan(decimal amount)
        {
            Amount = amount;
        }
    }
}
