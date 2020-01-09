using System;
using System.Threading.Tasks;
using Digital.Habitat.Api.Common.Models;
using Digital.Habitat.Api.Domain.Repositories;
using Digital.Habitat.Api.Domain.Repositories.UnitOfWorks;

namespace Digital.Habitat.Api.Data.Repositories.UnitOfWorks
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public UnitOfWork(
            //IDbContext context,
            ILoanRepository loanRepository,
            ICompanyRepository companyRepository)
        {
            //CustomContract.Requires<ArgumentNullException>(context != null, nameof(context));
            CustomContract.Requires<ArgumentNullException>(loanRepository != null, nameof(loanRepository));
            CustomContract.Requires<ArgumentNullException>(companyRepository != null, nameof(companyRepository));

            LoanRepository = loanRepository;
            CompanyRepository = companyRepository;
        }

        public ILoanRepository LoanRepository { get; }

        public ICompanyRepository CompanyRepository { get; }

        public void Save()
        {
            //_context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            //await _context.SaveChangesAsync();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                //_context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}