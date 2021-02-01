using MediatR;
using PersonalFinanceManagement.Domain.Shared;

namespace PersonalFinanceManagement.Infrastructure.Notifications
{
    public class DomainEventNotifications<TDomainEvent> : INotification where TDomainEvent: IDomainEvent
    {
        public DomainEventNotifications(TDomainEvent @event)
        {
            Event = @event;
        }

        public TDomainEvent Event { get; }
    }
}