using System;
using Digital.Habitat.Api.Common.Models;
using Digital.Habitat.Api.Domain.Repositories.UnitOfWorks;
using Microsoft.Extensions.Logging;

namespace Digital.Habitat.Api.Application.Services
{
    public abstract class BaseService
    {
        public IUnitOfWork UnitOfWork { get; }

        protected ILogger<BaseService> Logger { get; }

        protected BaseService(
            IUnitOfWork unitOfWork,
            ILogger<BaseService> logger)
        {
            CustomContract.Requires<ArgumentNullException>(logger != null, nameof(logger));
            CustomContract.Requires<ArgumentNullException>(unitOfWork != null, nameof(unitOfWork));

            Logger = logger;
            UnitOfWork = unitOfWork;
        }
    }
}