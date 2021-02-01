namespace PersonalFinanceManagement.Infrastructure.Notifications
{
    using System.Threading.Tasks;
    using PersonalFinanceManagement.Domain.Shared;

    public interface IEventDispatcher
    {
        Task DispatchAsync(IDomainEvent @event);
    }
}