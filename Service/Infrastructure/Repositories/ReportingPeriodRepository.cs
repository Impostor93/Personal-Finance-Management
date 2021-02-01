namespace PersonalFinanceManagement.Infrastructure.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Domain.Repositories;
    using PersonalFinanceManagement.Domain.Shared;
    using PersonalFinanceManagement.Infrastructure.Database;

    public class ReportingPeriodRepository : RepositoryBase<ReportingPeriod, Guid>, IReportingPeriodRepository
    {

        public ReportingPeriodRepository(PersonalFinanceManagementContext context)
            :base(context)
        {
        }

        public Task<ReportingPeriod> FindAsync(TimePeriod stratingPoint)
        {
            return context.Set<ReportingPeriod>().SingleOrDefaultAsync(e => e.TimePeriod == stratingPoint);
        }
    }
}