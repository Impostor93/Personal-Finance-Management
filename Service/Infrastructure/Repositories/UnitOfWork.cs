using System.Threading;
namespace PersonalFinanceManagement.Infrastructure.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using PersonalFinanceManagement.Domain.Repositories;
    using PersonalFinanceManagement.Infrastructure.Database;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonalFinanceManagementContext context;

        Lazy<ICategoryRepository> categoryRepository;
        public ICategoryRepository CategoryRepository =>categoryRepository.Value;

        Lazy<IReportingPeriodRepository> reportingPeriodRepository { get; }
        public IReportingPeriodRepository ReportingPeriodRepository => reportingPeriodRepository.Value;

        public UnitOfWork(IServiceProvider service, PersonalFinanceManagementContext context)
        {
            this.context = context;

            categoryRepository = new Lazy<ICategoryRepository>(() =>
            {
                return service.GetService<ICategoryRepository>();
            });
            reportingPeriodRepository = new Lazy<IReportingPeriodRepository>(() =>
            {
                return service.GetService<IReportingPeriodRepository>();
            });
        }

        public Task CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}