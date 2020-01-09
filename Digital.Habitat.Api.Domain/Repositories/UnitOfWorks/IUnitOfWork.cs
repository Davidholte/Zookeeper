using System.Threading.Tasks;

namespace Digital.Habitat.Api.Domain.Repositories.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        void Save();
        void Dispose();

        ILoanRepository LoanRepository { get; }

        ICompanyRepository CompanyRepository { get; }
    }
}