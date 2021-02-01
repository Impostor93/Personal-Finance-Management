namespace PersonalFinanceManagement.Infrastructure.Database
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Domain.Shared;
    using PersonalFinanceManagement.Infrastructure.Database.ModelConfigurations;
    using PersonalFinanceManagement.Infrastructure.Notifications;

    public class PersonalFinanceManagementContext : DbContext
    {
        private readonly IEventDispatcher eventDispatcher;

        public PersonalFinanceManagementContext([NotNullAttribute] DbContextOptions options, IEventDispatcher eventDispatcher) 
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PeriodModelConfiguration());
            modelBuilder.ApplyConfiguration(new ExprensesModelConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ReportingPeriod> Period { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            var entities = this.ChangeTracker
                .Entries<IAggregate>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventDispatcher.DispatchAsync(domainEvent);
                }
            }

            return result;
        }
    }
}
