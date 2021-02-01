using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PersonalFinanceManagement.Domain.Model.Events;
using PersonalFinanceManagement.Domain.Shared;
using PersonalFinanceManagement.Infrastructure.Notifications;

namespace Application.Notifications
{
    public class PeriodStartedHandler : INotificationHandler<DomainEventNotifications<PeriodStarted>>
    {
        public Task Handle(DomainEventNotifications<PeriodStarted> notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => {});
        }
    }
}