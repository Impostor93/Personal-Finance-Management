namespace PersonalFinanceManagement.Domain.Exceptions
{
    using System;
    using PersonalFinanceManagement.Domain.Model;

    public class InvalidPeriodException : BaseDomainException
    {
        public InvalidPeriodException(TimePeriod timePeriod, string message)
            : this($"Invalid period time from '{timePeriod.StartingPoint}' to '{timePeriod.EndPoint}'. {message}")
        {

        }

        public InvalidPeriodException(string error) => this.Error = error;
    }
}
