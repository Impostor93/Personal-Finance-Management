using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceManagement.Domain.Shared
{
    public interface IAggregate<T> : IEntity<T>, IAggregate
    {
    }
    public interface IAggregate
    {
        IEnumerable<IDomainEvent> Events { get; }

        void ClearEvents();
    }
}