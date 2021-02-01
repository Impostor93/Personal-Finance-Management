namespace PersonalFinanceManagement.Application.Commands
{
    using System;
    using MediatR;
    using PersonalFinanceManagement.Application.Common;

    public class StartNewReportingPeriodCommand : IRequest<Result>
    {
        public StartNewReportingPeriodCommand(){}
        public StartNewReportingPeriodCommand(Guid ownerId, DateTime startingPoint, DateTime endPoint)
        {
            OwnerId = ownerId;
            StartingPoint = startingPoint;
            EndPoint = endPoint;
        }

        public Guid OwnerId { get; set; }

        public DateTime StartingPoint { get; set;}

        public DateTime EndPoint { get; set; }
    }
}