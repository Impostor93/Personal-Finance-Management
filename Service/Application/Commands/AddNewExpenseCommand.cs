namespace PersonalFinanceManagement.Application.Commands
{
    using System;
    using MediatR;
    using PersonalFinanceManagement.Application.Common;
    using PersonalFinanceManagement.Domain.Model;

    public class AddNewExpenseCommand : IRequest<Result>
    {
        public Guid PeriodId { get; set; }
        public Purchase Purchase { get; set; }

        public AddNewExpenseCommand(){}
        public AddNewExpenseCommand(Guid periodId, Purchase purchase)
        {
            this.PeriodId = periodId;
            this.Purchase = purchase;
        }
    }
}