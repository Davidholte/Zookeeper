using System;
using Digital.Habitat.Api.Common.Models;
using Digital.Habitat.Api.Domain.Common;

namespace Digital.Habitat.Api.Domain.Models.Loans
{
    public class LoanId : Identity<Guid, LoanId>
    {
        public override Guid Id { get; }

        public LoanId(Guid id)
        {
            CustomContract.Requires<NullReferenceException>(Guid.Empty != id, nameof(id));

            Id = id;
        }

    }
}
