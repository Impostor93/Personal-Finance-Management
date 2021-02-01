namespace PersonalFinanceManagement.Domain.Model.Events
{
    using System;
    using PersonalFinanceManagement.Domain.Shared;

    public class ExpenseAdded : IDomainEvent
    {
        public ExpenseAdded(Guid periodId)
        {
            PeriodId = periodId;
        }

        public Guid PeriodId { get; }
    }
}
