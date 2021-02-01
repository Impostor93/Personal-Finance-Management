using System;
using PersonalFinanceManagement.Domain.Model;

namespace PersonalFinanceManagement.Domain.Exceptions
{
    public class StartingPointGraterThanEndPointException : BaseDomainException
    {
        public StartingPointGraterThanEndPointException(DateTime startingPoint, DateTime endPoint)
            : this($"The starting point must not be greater than the end point. StartingPoint '{startingPoint}', EndPoint '{endPoint}'.")
        {

        }

        public StartingPointGraterThanEndPointException(string error) => this.Error = error;
    }
}