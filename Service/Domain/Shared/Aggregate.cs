using System;
using System.Collections.Generic;

namespace PersonalFinanceManagement.Domain.Shared
{
    public abstract class Aggregate<T> : Entity<T>, IAggregate<T>
    {
        public IEnumerable<IDomainEvent> Events => events;
        List<IDomainEvent> events;

        public Aggregate()
        {
            events = new List<IDomainEvent>();
        }

        internal void AppendEvent(IDomainEvent @event)
        {
            if (ReferenceEquals(@event, null))
                throw new ArgumentNullException(nameof(@event));

            events.Add(@event);
        }
        public void RemoveEvent(IDomainEvent @event)
        {
            events.Remove(@event);
        }

        public void ClearEvents()
        {
            events.Clear();
        }
    }
}
