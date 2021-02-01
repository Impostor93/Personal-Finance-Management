namespace PersonalFinanceManagement.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalFinanceManagement.Domain.Exceptions;
    using PersonalFinanceManagement.Domain.Model.Events;
    using PersonalFinanceManagement.Domain.Shared;

    public class ReportingPeriod : Aggregate<Guid>
    {
        private Guid id;
        private HashSet<Expense> expenses;

        public override Guid Id => id;

        OwnerId ownerId;
        private TimePeriod timePeriod;

        public TimePeriod TimePeriod => timePeriod;

        public OwnerId OwnerId => ownerId;

        public IEnumerable<Expense> Expenses => expenses;

        public ReportingPeriod(){}
        private ReportingPeriod(OwnerId ownerId, TimePeriod timePeriod)
        {
            id = Guid.NewGuid();
            this.ownerId = ownerId;
            this.timePeriod = timePeriod;
            
            expenses = new HashSet<Expense>();
        }

        public void RegisterExpense(Producer producer, Purchase purchase)
        {
            var expense = Expense.Produce(producer.Identifier, purchase.HappendOn, new Money(purchase.Price), purchase.CategoryId);
            
            if(timePeriod.IsDateInRange(purchase.HappendOn) == false)
                throw new ExpenseIsOutOfDateTimeRangeException();

            expenses.Add(expense);

            this.AppendEvent(new ExpenseAdded(id));
        }

        public static ReportingPeriod Start(Owner owner, TimePeriod timePeriod)
        {
            Guard.ThrowIfItIsNull(owner, nameof(owner));

            var period = new ReportingPeriod(owner.Id, timePeriod);
            period.AppendEvent(new PeriodStarted(period.id));

            return period;
        }
    }
}
