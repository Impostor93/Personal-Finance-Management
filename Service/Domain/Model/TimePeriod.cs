namespace PersonalFinanceManagement.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using PersonalFinanceManagement.Domain.Exceptions;
    using PersonalFinanceManagement.Domain.Shared;

    public class TimePeriod : ValueObject
    {
        private DateTime startingPoint;
        public DateTime StartingPoint => startingPoint;

        private DateTime endPoint;
        public DateTime EndPoint => endPoint;

        public TimePeriod(DateTime startingPoint, DateTime endPoint)
        {
            Guard.ThrowIfItIsNull(startingPoint, nameof(startingPoint));
            Guard.ThrowIfItIsNull(endPoint, nameof(endPoint));

            if(startingPoint > endPoint)
                throw new StartingPointGraterThanEndPointException(startingPoint, endPoint);

            this.startingPoint = startingPoint;
            this.endPoint = endPoint;
        }

        public bool IsDateInRange(DateTime dateTime)
        {
            return dateTime > startingPoint && endPoint > dateTime;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartingPoint;
            yield return EndPoint;
        }
    }
}