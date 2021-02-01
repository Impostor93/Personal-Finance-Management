using System;
namespace PersonalFinanceManagement.Infrastructure.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using PersonalFinanceManagement.Domain.Shared;

    public abstract class RepositoryBase<T, Tid> : IRepository<T, Tid> where T : Aggregate<Tid>
    {
        protected readonly DbContext context;
        
        private DbSet<T> Set;

        public RepositoryBase(DbContext context)
        {
            this.Set = context.Set<T>();
            this.context = context;
        }

        public Task<T> FindByIdAsync(Tid id)
        {
            return Set.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task StoreAsync(T aggregate)
        {
            await Set.AddAsync(aggregate);
        }
    }
}