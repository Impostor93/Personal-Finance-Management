using System;

namespace PersonalFinanceManagement.Domain.Shared
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}
