namespace PersonalFinanceManagement.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using PersonalFinanceManagement.Domain.Shared;

    public class Money : ValueObject
    {
        public float Amount { get; }

        public Money(float amount)
        {
            Amount = amount;
        }

        public Money Append(float amount)
        {
            return new Money((this.Amount + amount));
        }

        public Money Substract(float amount)
        {
            if(Amount < amount)
                throw new Exception("Money could not be negative value");

            return new Money((this.Amount - amount));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}
