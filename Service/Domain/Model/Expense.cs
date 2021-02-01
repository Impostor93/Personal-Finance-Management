using System.Net.Http.Headers;
namespace PersonalFinanceManagement.Domain.Model
{
    using System;
    using PersonalFinanceManagement.Domain.Shared;

    public class Expense : Entity<int>
    {
        private int id;

        public override int Id => id;

        ProducerId producerId;
        public ProducerId ProducerId => producerId;

        DateTime occurredAt;
        public DateTime OccurredAt => occurredAt;

        Money cost;
        public Money Cost => cost;

        CategoryId categoryId;
        public CategoryId CategoryId => categoryId;

        public Guid PeriodId { get; set; }

        public Expense() { }

        Expense(ProducerId producerId, DateTime occurred, Money cost, CategoryId categoryId)
        {
            this.producerId = producerId;
            this.occurredAt = occurred;
            this.cost = cost;
            this.categoryId = categoryId;
        }

        //fits better in the lenguage 
        public static Expense Produce(ProducerId producerId, DateTime occurred, Money cost, CategoryId categoryId)
        {
            Guard.ThrowIfItIsNull(producerId, nameof(producerId));
            Guard.ThrowIfItIsNull(occurred, nameof(occurred));
            Guard.ThrowIfItIsNull(cost, nameof(cost));
            Guard.ThrowIfItIsNull(categoryId, nameof(categoryId));

            return new Expense(producerId, occurred, cost, categoryId);
        }
    }
}