namespace PersonalFinanceManagement.Domain.Shared
{
    using System.Threading.Tasks;

    public interface IRepository<T, Tid> where T: IAggregate<Tid>
    {
        Task<T> FindByIdAsync(Tid id);

        Task StoreAsync(T aggregate);
    }
}