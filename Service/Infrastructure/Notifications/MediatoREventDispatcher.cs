namespace PersonalFinanceManagement.Infrastructure.Notifications
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using PersonalFinanceManagement.Domain.Shared;

    public class MediatoREventDispatcher : IEventDispatcher
    {
        private readonly IMediator mediator;

        public MediatoREventDispatcher(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task DispatchAsync(IDomainEvent @event)
        {
            var domainEventNotificationsType = typeof(DomainEventNotifications<>);
            var typeArgs = new [] { @event.GetType() };
            var makeme = domainEventNotificationsType.MakeGenericType(typeArgs);
            var domainNotification = Activator.CreateInstance(makeme, new [] { @event });

            return mediator.Publish(domainNotification);
        }
    }
}