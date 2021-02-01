namespace PersonalFinanceManagement.Domain.Repositories
{
    using System;
    using System.Threading.Tasks;
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Domain.Shared;

    public interface IReportingPeriodRepository : IRepository<ReportingPeriod, Guid>
    {
        Task<ReportingPeriod> FindAsync(TimePeriod stratingPoint);
    }
}