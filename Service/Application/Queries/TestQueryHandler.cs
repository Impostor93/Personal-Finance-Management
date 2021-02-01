using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PersonalFinanceManagement.Domain.Model;
using System.Linq;
using PersonalFinanceManagement.Infrastructure.Database;

namespace Application.Queries
{
    public class TestQueryHandler : IRequestHandler<TestQuery, object>
    {
        private readonly PersonalFinanceManagementContext context;
        public TestQueryHandler(PersonalFinanceManagementContext context)
        {
            this.context = context;
        }

        public Task<object> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            using (context)
            {
                var ownerId = new OwnerId(Guid.Parse("2f9abcbc-d607-4806-8248-5a8777a60538"));
                var period = context.Set<ReportingPeriod>().FirstOrDefault(e => e.OwnerId == ownerId);
                if (period == null)
                    return null;

                var res = new { PeriodBounderies = $"{period.TimePeriod.StartingPoint} - {period.TimePeriod.EndPoint}" };
                return Task.FromResult((object)res);
            }
        }
    }
}