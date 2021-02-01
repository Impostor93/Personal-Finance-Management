namespace PersonalFinanceManagement.Application.CommandHandlers
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using PersonalFinanceManagement.Application.Commands;
    using PersonalFinanceManagement.Application.Common;
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Infrastructure.Database;
    using PersonalFinanceManagement.Infrastructure.Repositories;

    public class ReportingPeriodHandler : 
        IRequestHandler<StartNewReportingPeriodCommand, Result>,
        IRequestHandler<AddNewExpenseCommand, Result>
    {
        private readonly IUnitOfWork unitOfWork;

        public ReportingPeriodHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(StartNewReportingPeriodCommand request, CancellationToken cancellationToken)
        {
            using (unitOfWork)
            {
                var owner = new Owner(request.OwnerId);
                var period = ReportingPeriod.Start(owner, new TimePeriod(request.StartingPoint, request.EndPoint));

                await unitOfWork.ReportingPeriodRepository.StoreAsync(period);

                await unitOfWork.CommitAsync(cancellationToken);

                return Result.Success;
            }
        }

        public async Task<Result> Handle(AddNewExpenseCommand request, CancellationToken cancellationToken)
        {
            using(unitOfWork)
            {
                var period = await unitOfWork.ReportingPeriodRepository.FindByIdAsync(request.PeriodId);
                if(ReferenceEquals(period, null))
                    throw new Exception($"Unable to find period '{request.PeriodId}'");
                
                var producer = new Producer(new ProducerId(request.PeriodId));
                period.RegisterExpense(producer, request.Purchase);

                await unitOfWork.CommitAsync(cancellationToken);

                return Result.Success;
            }
        }
    }
}