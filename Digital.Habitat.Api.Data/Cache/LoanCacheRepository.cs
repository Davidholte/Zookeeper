using Digital.Habitat.Api.Data.Cache.Base;
using Digital.Habitat.Api.Domain.Models.Loans;
using Digital.Habitat.Api.Domain.Repositories;

namespace Digital.Habitat.Api.Data.Cache
{
    public class LoanCacheRepository : BaseCacheDataLayer, ILoanRepository
    {
        public Loan GetById(LoanId loanId)
        {
            throw new System.NotImplementedException();
        }
    }
}
