using System;
using System.Threading;
using System.Threading.Tasks;
using PersonalFinanceManagement.Domain.Repositories;

namespace PersonalFinanceManagement.Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        IReportingPeriodRepository ReportingPeriodRepository { get; }

        Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}