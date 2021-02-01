namespace PersonalFinanceManagement.Domain.Model.Events
{
    using System;
    using PersonalFinanceManagement.Domain.Shared;

    public class PeriodStarted : IDomainEvent
    {
        public Guid PeriodId { get; }

        public PeriodStarted(Guid periodId)
        {
            PeriodId = periodId;
        }
    }
}
